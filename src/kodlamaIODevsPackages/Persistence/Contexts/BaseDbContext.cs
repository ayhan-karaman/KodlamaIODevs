using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Persistence.Contexts;
public class BaseDbContext:DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<UserSocialMedia> UserSocialMedias { get; set; }

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

         modelBuilder.Entity<User>(user =>{
            user.ToTable("users").HasKey(k => k.Id);
            user.Property(p =>p.Id).HasColumnName("user_id");
            user.Property(p => p.FirstName).HasColumnName("first_name");
            user.Property(p => p.LastName).HasColumnName("last_name");
            user.Property(p => p.Email).HasColumnName("email");
            user.Property(p => p.PasswordHash).HasColumnName("password_hash");
            user.Property(p => p.PasswordSalt).HasColumnName("password_salt");
            user.Property(p => p.Status).HasColumnName("status");
            user.Property(p => p.AuthenticatorType).HasColumnName("authenticator_type");
            user.HasMany(p => p.RefreshTokens);
            user.HasMany(p => p.UserOperationClaims);
            user.HasMany(p => p.UserSocialMedias);
            
         });

         modelBuilder.Entity<OperationClaim>(opc => {
            opc.ToTable("operation_claims").HasKey(k=>k.Id);
            opc.Property(p => p.Id).HasColumnName("operation_claim_id");
            opc.Property(p => p.Name).HasColumnName("operation_claim_name");
         });

         modelBuilder.Entity<UserOperationClaim>(opc => {
            opc.ToTable("user_operation_claims").HasKey(k=>k.Id);
            opc.Property(p => p.Id).HasColumnName("user_operation_claim_id");
            opc.Property(p => p.OperationClaimId).HasColumnName("operation_claim_id");
            opc.Property(p => p.UserId).HasColumnName("user_id");
            opc.HasOne(p => p.User);
            opc.HasOne(p => p.OperationClaim);
            
         });

         modelBuilder.Entity<UserSocialMedia>(sc => {
            sc.ToTable("user_social_medias").HasKey(k => k.Id);
            sc.Property(p => p.Id).HasColumnName("user_social_media_id");
            sc.Property(p => p.UserId).HasColumnName("user_id");
            sc.Property(p => p.SocialMediaName).HasColumnName("social_media_name");
            sc.Property(p => p.Url).HasColumnName("url");
            sc.HasOne(p => p.User);
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

        OperationClaim[] claimsSeeds = { new (1, "User"), new (2, "Admin")};
        modelBuilder.Entity<OperationClaim>().HasData(claimsSeeds);



        UserSocialMedia[]  userSocialMediasSeeds = {
         new (1, 1, "Github", "https://github.com/engindemirog/"),
         new (2, 1, "Youtube", "https://linkedin.com/in/engindemirog")
         };

         modelBuilder.Entity<UserSocialMedia>().HasData(userSocialMediasSeeds);

        

    }
}