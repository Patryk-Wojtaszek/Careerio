﻿// <auto-generated />
using System;
using Careerio.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Careerio.Migrations
{
    [DbContext(typeof(CareerioDbContext))]
    [Migration("20220607172946_init6")]
    partial class init6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Careerio.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Careerio.Authentication.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Careerio.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Careerio.Models.Benefit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Benefits")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Benefits");
                });

            modelBuilder.Entity("Careerio.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<int>("BenefitId")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("DateOfStarting")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GalleryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfEmployees")
                        .HasColumnType("int");

                    b.Property<int>("RelatedIndustryId")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TechnologyId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("BenefitId")
                        .IsUnique();

                    b.HasIndex("CreatedById");

                    b.HasIndex("GalleryId")
                        .IsUnique()
                        .HasFilter("[GalleryId] IS NOT NULL");

                    b.HasIndex("RelatedIndustryId")
                        .IsUnique();

                    b.HasIndex("TechnologyId")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Careerio.Models.ExperienceLevel", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("ExperienceLevelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExperienceLevels");
                });

            modelBuilder.Entity("Careerio.Models.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Photos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Galleries");
                });

            modelBuilder.Entity("Careerio.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<byte>("ExperienceLevelId")
                        .HasColumnType("tinyint");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RemoteRecruitmentId")
                        .HasColumnType("tinyint");

                    b.Property<int>("RequirementId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsibilityId")
                        .HasColumnType("int");

                    b.Property<int>("SalaryFrom")
                        .HasColumnType("int");

                    b.Property<int>("SalaryTo")
                        .HasColumnType("int");

                    b.Property<byte>("TypeOfContractId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("WorkingHoursID")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ExperienceLevelId");

                    b.HasIndex("RemoteRecruitmentId");

                    b.HasIndex("RequirementId")
                        .IsUnique();

                    b.HasIndex("ResponsibilityId")
                        .IsUnique();

                    b.HasIndex("TypeOfContractId");

                    b.HasIndex("WorkingHoursID");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("Careerio.Models.RelatedIndustry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RelatedIndustries")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RelatedIndustries");
                });

            modelBuilder.Entity("Careerio.Models.RemoteRecruitment", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsRemoteRecruitment")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RemoteRecruitments");
                });

            modelBuilder.Entity("Careerio.Models.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Requirements")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("Careerio.Models.Responsibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Responsibilities")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Responsibilities");
                });

            modelBuilder.Entity("Careerio.Models.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Technologies")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Technologies");
                });

            modelBuilder.Entity("Careerio.Models.TypeOfContract", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Shortcut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfContractDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeOfContracts");
                });

            modelBuilder.Entity("Careerio.Models.WorkingHours", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("WorkingHoursDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("Careerio.Authentication.User", b =>
                {
                    b.HasOne("Careerio.Authentication.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Careerio.Models.Company", b =>
                {
                    b.HasOne("Careerio.Models.Address", "Address")
                        .WithOne("Company")
                        .HasForeignKey("Careerio.Models.Company", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.Benefit", "Benefit")
                        .WithOne("Company")
                        .HasForeignKey("Careerio.Models.Company", "BenefitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Authentication.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Careerio.Models.Gallery", "Gallery")
                        .WithOne("Company")
                        .HasForeignKey("Careerio.Models.Company", "GalleryId");

                    b.HasOne("Careerio.Models.RelatedIndustry", "RelatedIndustry")
                        .WithOne("Company")
                        .HasForeignKey("Careerio.Models.Company", "RelatedIndustryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.Technology", "Technology")
                        .WithOne("Company")
                        .HasForeignKey("Careerio.Models.Company", "TechnologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Benefit");

                    b.Navigation("CreatedBy");

                    b.Navigation("Gallery");

                    b.Navigation("RelatedIndustry");

                    b.Navigation("Technology");
                });

            modelBuilder.Entity("Careerio.Models.JobOffer", b =>
                {
                    b.HasOne("Careerio.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.ExperienceLevel", "ExperienceLevel")
                        .WithMany()
                        .HasForeignKey("ExperienceLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.RemoteRecruitment", "RemoteRecruitment")
                        .WithMany()
                        .HasForeignKey("RemoteRecruitmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.Requirement", "Requirement")
                        .WithOne("JobOffer")
                        .HasForeignKey("Careerio.Models.JobOffer", "RequirementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.Responsibility", "Responsibility")
                        .WithOne("JobOffer")
                        .HasForeignKey("Careerio.Models.JobOffer", "ResponsibilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.TypeOfContract", "TypeOfContract")
                        .WithMany()
                        .HasForeignKey("TypeOfContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Careerio.Models.WorkingHours", "WorkingHours")
                        .WithMany()
                        .HasForeignKey("WorkingHoursID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("ExperienceLevel");

                    b.Navigation("RemoteRecruitment");

                    b.Navigation("Requirement");

                    b.Navigation("Responsibility");

                    b.Navigation("TypeOfContract");

                    b.Navigation("WorkingHours");
                });

            modelBuilder.Entity("Careerio.Models.Address", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("Careerio.Models.Benefit", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("Careerio.Models.Gallery", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("Careerio.Models.RelatedIndustry", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("Careerio.Models.Requirement", b =>
                {
                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("Careerio.Models.Responsibility", b =>
                {
                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("Careerio.Models.Technology", b =>
                {
                    b.Navigation("Company");
                });
#pragma warning restore 612, 618
        }
    }
}
