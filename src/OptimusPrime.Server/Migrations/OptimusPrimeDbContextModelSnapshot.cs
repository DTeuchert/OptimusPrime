﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptimusPrime.Server.Persistences;

namespace OptimusPrime.Server.Migrations
{
    [DbContext(typeof(OptimusPrimeDbContext))]
    partial class OptimusPrimeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("OptimusPrime.Server.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Main"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Autobot Cars"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mini-Bots"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dinobots"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Aerialbots"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Protectobots"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Female Autobots"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Technobots"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Throttlebots"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Targetmasters"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Headmasters"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Clonebots"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Junkions"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Others"
                        });
                });

            modelBuilder.Entity("OptimusPrime.Server.Entities.Transformer", b =>
                {
                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("Alliance")
                        .IsRequired();

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Guid");

                    b.HasIndex("CategoryId");

                    b.ToTable("Transformers");

                    b.HasData(
                        new
                        {
                            Guid = "35d663b8-e087-4e4e-8cae-fc31258f7c99",
                            Alliance = "Autobot",
                            CategoryId = 1,
                            Name = "Optimus Prime"
                        },
                        new
                        {
                            Guid = "8a185940-0f60-46bd-97bd-9f122662fb85",
                            Alliance = "Autobot",
                            CategoryId = 1,
                            Name = "Bumblebee"
                        },
                        new
                        {
                            Guid = "faaddd1b-92d7-47ac-b7d6-13be803ca63c",
                            Alliance = "Autobot",
                            CategoryId = 1,
                            Name = "Cliffjumper"
                        },
                        new
                        {
                            Guid = "d5a1b9ce-3e63-4188-be5c-d3f640eded2e",
                            Alliance = "Decepticon",
                            CategoryId = 1,
                            Name = "Megatron"
                        });
                });

            modelBuilder.Entity("OptimusPrime.Server.Entities.Transformer", b =>
                {
                    b.HasOne("OptimusPrime.Server.Entities.Category", "Category")
                        .WithMany("Transformers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
