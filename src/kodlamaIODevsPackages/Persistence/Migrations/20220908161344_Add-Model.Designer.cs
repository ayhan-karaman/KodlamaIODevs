// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence.Contexts;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220908161344_Add-Model")]
    partial class AddModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("language_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("language_isActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("language_name");

                    b.HasKey("Id");

                    b.ToTable("languages", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Csharp"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Java"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Javascript"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("technology_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LanguageId")
                        .HasColumnType("integer")
                        .HasColumnName("technology_language_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("technology_name");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("technologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageId = 1,
                            Name = "Wpf"
                        },
                        new
                        {
                            Id = 2,
                            LanguageId = 1,
                            Name = "ASP.NET"
                        },
                        new
                        {
                            Id = 3,
                            LanguageId = 2,
                            Name = "Spring"
                        },
                        new
                        {
                            Id = 4,
                            LanguageId = 2,
                            Name = "Jsp"
                        },
                        new
                        {
                            Id = 5,
                            LanguageId = 3,
                            Name = "React"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Technology", b =>
                {
                    b.HasOne("Domain.Entities.Language", "Language")
                        .WithMany("Technologies")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Domain.Entities.Language", b =>
                {
                    b.Navigation("Technologies");
                });
#pragma warning restore 612, 618
        }
    }
}
