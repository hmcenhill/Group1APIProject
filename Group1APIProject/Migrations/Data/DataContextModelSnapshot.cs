﻿// <auto-generated />
using Group1APIProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Group1APIProject.Migrations.Data
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Group1APIProject.Models.RecipeFavorite", b =>
                {
                    b.Property<int>("RecipeFavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ResultId");

                    b.Property<int>("UserDataId");

                    b.HasKey("RecipeFavoriteId");

                    b.HasIndex("ResultId");

                    b.HasIndex("UserDataId");

                    b.ToTable("RecipeFavorites");
                });

            modelBuilder.Entity("Group1APIProject.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Href");

                    b.Property<string>("Ingredients");

                    b.Property<string>("Thumbnail");

                    b.Property<string>("Title");

                    b.HasKey("ResultId");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("Group1APIProject.Models.UserData", b =>
                {
                    b.Property<int>("UserDataID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserName");

                    b.HasKey("UserDataID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Group1APIProject.Models.RecipeFavorite", b =>
                {
                    b.HasOne("Group1APIProject.Models.Result", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Group1APIProject.Models.UserData", "UserData")
                        .WithMany("RecipeFavorites")
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
