using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence.Contexts;
public class BaseDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Language> Languages { get; set; }

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
         });

         Language[] languageEntitySeeds = {
            new Language{Id= 1, Name = "CSharp", IsActive = true }, 
            new Language{Id = 2, Name = "Java", IsActive = true }, 
            new Language{Id=3, Name="Javascript", IsActive = true }
            };
         modelBuilder.Entity<Language>().HasData(languageEntitySeeds);
    }
}