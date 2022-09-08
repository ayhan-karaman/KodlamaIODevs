using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence.Contexts;
public class BaseDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Technology> Technologies { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration confitguration):base(dbContextOptions)
    {
        Configuration = confitguration;
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(lng => 
         {
            lng.ToTable("languages").HasKey(k => k.Id);
            lng.Property(p => p.Id).HasColumnName("language_id");
            lng.Property(p => p.Name).HasColumnName("language_name");
            lng.Property(p => p.IsActive).HasColumnName("language_isActive");
            lng.HasMany(p => p.Technologies);
         });

         modelBuilder.Entity<Technology>(tech =>{
            tech.ToTable("technologies").HasKey(t => t.Id);
            tech.Property(p => p.Id).HasColumnName("technology_id");
            tech.Property(p => p.LanguageId).HasColumnName("technology_language_id");
            tech.Property(p => p.Name).HasColumnName("technology_name");
            tech.HasOne(p => p.Language);
         });

         Language[] languageEntitySeeds = {
            new (1, "Csharp", true), 
            new (2,  "Java", true ), 
            new (3,"Javascript", true)
            };
         modelBuilder.Entity<Language>().HasData(languageEntitySeeds);

         Technology[] technologyEntitySeeds = 
         {
            new(1, 1, "Wpf"),
            new(2, 1, "ASP.NET"),
            new(3, 2, "Spring"),
            new(4, 2, "Jsp"),
            new(5, 3, "React")
         };
         modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);
    }
}