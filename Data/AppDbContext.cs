using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using study_center_ef.Entities;

public class AppDbContext : DbContext
{
    public DbSet<Class> Classes { get; set; }
    public DbSet<GradeLevel> GradeLevels { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Student> Students { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetSection("connectionString").Value;

        optionsBuilder.UseSqlServer(connectionString);

        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

    }

}
