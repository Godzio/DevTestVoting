// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnweloApi.OnweloApiDbContext;

namespace OnweloApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnweloApi.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Candidate 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Candidate 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Candidate 3"
                        });
                });

            modelBuilder.Entity("OnweloApi.Models.Voter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("Voters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Voter 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Voter 2"
                        });
                });

            modelBuilder.Entity("OnweloApi.Models.Voter", b =>
                {
                    b.HasOne("OnweloApi.Models.Candidate", "CandidateVotedOn")
                        .WithMany("Voters")
                        .HasForeignKey("CandidateId");

                    b.Navigation("CandidateVotedOn");
                });

            modelBuilder.Entity("OnweloApi.Models.Candidate", b =>
                {
                    b.Navigation("Voters");
                });
#pragma warning restore 612, 618
        }
    }
}
