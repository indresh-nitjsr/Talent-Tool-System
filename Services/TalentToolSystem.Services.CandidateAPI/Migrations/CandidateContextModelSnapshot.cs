﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TalentToolSystem.Services.CandidateAPI.Data;

#nullable disable

namespace TalentToolSystem.Services.CandidateAPI.Migrations
{
    [DbContext(typeof(CandidateContext))]
    partial class CandidateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TalentToolSystem.Services.CandidateAPI.Model.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CandidateId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CTC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CandidateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ECTC")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NoticePeriod")
                        .HasColumnType("int");

                    b.Property<int>("ReferralId")
                        .HasColumnType("int");

                    b.Property<string>("SkillSet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfExperience")
                        .HasColumnType("int");

                    b.HasKey("CandidateId");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            CandidateId = 1,
                            Account = "Salesforce",
                            CTC = 10m,
                            CandidateName = "Indresh Kumar Maurya",
                            CurrentCompany = "Nexturn",
                            ECTC = 10m,
                            Email = "indresh@gmail.com",
                            Location = "Mirzapur",
                            Manager = "Gunjan",
                            Mobile = "7823637281",
                            NoticePeriod = 10,
                            ReferralId = 101,
                            SkillSet = "C++,.Net,Sql Server",
                            Status = "Selected",
                            YearOfExperience = 1
                        },
                        new
                        {
                            CandidateId = 2,
                            Account = "Salesforce",
                            CTC = 10m,
                            CandidateName = "Shobhit Kumar Singh",
                            CurrentCompany = "Nexturn",
                            ECTC = 10m,
                            Email = "shobhit@gmail.com",
                            Location = "Patna",
                            Manager = "Gunjan",
                            Mobile = "7823637281",
                            NoticePeriod = 10,
                            ReferralId = 101,
                            SkillSet = "C++,.Net,Sql Server",
                            Status = "Selected",
                            YearOfExperience = 1
                        },
                        new
                        {
                            CandidateId = 3,
                            Account = "Amazon",
                            CTC = 10m,
                            CandidateName = "Abuzar Nasim",
                            CurrentCompany = "Nexturn",
                            ECTC = 10m,
                            Email = "abuzar@gmail.com",
                            Location = "Ranchi",
                            Manager = "Gunjan",
                            Mobile = "7823637281",
                            NoticePeriod = 10,
                            ReferralId = 101,
                            SkillSet = "C++,.Net,Sql Server",
                            Status = "Selected",
                            YearOfExperience = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
