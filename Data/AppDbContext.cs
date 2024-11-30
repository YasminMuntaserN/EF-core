using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using study_center_ef.Entities;
using System.Xml.Serialization;

public class AppDbContext : DbContext
{
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<GradeLevel> GradeLevels { get; set; }
    public DbSet<GradeLevelSubject> GradeLevelSubjects { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<TeacherDetail> TeachersDetails { get; set; }
    public DbSet<StudentDetail> StudentsDetails { get; set; }
    public DbSet<MeetingTime> MeetingTimes { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetSection("connectionString").Value;

        optionsBuilder.UseSqlServer(connectionString);

        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));

        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

    }

  
    // Mapping the SQL Server scalar-valued function to Entity Framework Core.
    // This attribute defines the function name and schema in the database.
    [DbFunction("CheckIfThereIsGroupInSpecificTime", Schema = "ado")]
    public string CheckIfThereIsGroupInSpecificTime(DateTime StartDate, DateTime EndDate)
    {
        // This method doesn't require an implementation in C#.
        // EF Core uses this method as a bridge to call the corresponding SQL Server function.
        // When we invoke this method in LINQ queries, EF Core translates it into a call 
        // to the mapped SQL function "CheckIfThereIsGroupInSpecificTime" in the database.

        // The SQL function checks if there is an active group scheduled at a specific time
        // by comparing the given start and end times against the 'MeetingTimes' table 
        // and verifying the 'IsActive' status from the 'Groups' table.

        // Throws an exception if called directly in code outside of a LINQ-to-SQL context.
        throw new NotImplementedException();
    }

}
