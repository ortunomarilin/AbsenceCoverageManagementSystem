﻿// <auto-generated />
using System;
using AbsenceCoverageMS.Models.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AbsenceCoverageMS.Migrations
{
    [DbContext(typeof(AbsenceManagementContext))]
    [Migration("20200506131347_AddedPeriodNumberToPeriodEntity")]
    partial class AddedPeriodNumberToPeriodEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.AbsenceRequest", b =>
                {
                    b.Property<string>("AbsenceRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AbsenceTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateProcessed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSubmitted")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("DurationTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool>("NeedCoverage")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("StartDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusRemarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AbsenceRequestId");

                    b.HasIndex("AbsenceTypeId");

                    b.HasIndex("DurationTypeId");

                    b.HasIndex("StatusTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("AbsenceRequests");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.AbsenceRequestPeriod", b =>
                {
                    b.Property<string>("AbsenceRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PeriodId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AbsenceRequestId", "PeriodId");

                    b.HasIndex("PeriodId");

                    b.ToTable("AbsenceRequestPeriod");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.AbsenceType", b =>
                {
                    b.Property<string>("AbsenceTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbsenceTypeId");

                    b.ToTable("AbsenceTypes");

                    b.HasData(
                        new
                        {
                            AbsenceTypeId = "1",
                            Name = "PTO"
                        },
                        new
                        {
                            AbsenceTypeId = "2",
                            Name = "Business/Professional"
                        },
                        new
                        {
                            AbsenceTypeId = "3",
                            Name = "Jury Duty"
                        });
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.Campus", b =>
                {
                    b.Property<string>("CampusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CloseTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpenTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampusId");

                    b.ToTable("Campuses");

                    b.HasData(
                        new
                        {
                            CampusId = "0",
                            City = "Houston",
                            CloseTime = new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Home Office",
                            OpenTime = new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Phone = "713-111-1111",
                            State = 41,
                            StreetAddress = "444 Street",
                            ZipCode = "7704"
                        },
                        new
                        {
                            CampusId = "1",
                            City = "Houston",
                            CloseTime = new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "South",
                            OpenTime = new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Phone = "713-123-1231",
                            State = 41,
                            StreetAddress = "111 Street",
                            ZipCode = "7701"
                        },
                        new
                        {
                            CampusId = "2",
                            City = "Houston",
                            CloseTime = new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "West",
                            OpenTime = new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Phone = "713-123-1232",
                            State = 41,
                            StreetAddress = "222 Street",
                            ZipCode = "7702"
                        },
                        new
                        {
                            CampusId = "3",
                            City = "Houston",
                            CloseTime = new DateTime(2020, 8, 1, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "East",
                            OpenTime = new DateTime(2020, 8, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            Phone = "713-123-1233",
                            State = 41,
                            StreetAddress = "333 Street",
                            ZipCode = "7703"
                        },
                        new
                        {
                            CampusId = "4",
                            City = "Houston",
                            CloseTime = new DateTime(2020, 8, 1, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "North",
                            OpenTime = new DateTime(2020, 8, 1, 7, 0, 0, 0, DateTimeKind.Unspecified),
                            Phone = "713-123-1234",
                            State = 41,
                            StreetAddress = "444 Street",
                            ZipCode = "7704"
                        });
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CourseId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("UserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.CoveragePeriod", b =>
                {
                    b.Property<string>("CoveragePeriodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Count")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PeriodId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CoveragePeriodId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CoveragePeriods");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.DurationType", b =>
                {
                    b.Property<string>("DurationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DurationTypeId");

                    b.ToTable("DurationTypes");

                    b.HasData(
                        new
                        {
                            DurationTypeId = "1",
                            Name = "Full Day"
                        },
                        new
                        {
                            DurationTypeId = "2",
                            Name = "Half Day"
                        });
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.Period", b =>
                {
                    b.Property<string>("PeriodId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PeriodNumber")
                        .HasColumnType("int");

                    b.HasKey("PeriodId");

                    b.ToTable("Periods");

                    b.HasData(
                        new
                        {
                            PeriodId = "1",
                            Name = "Period 1",
                            PeriodNumber = 1
                        },
                        new
                        {
                            PeriodId = "2",
                            Name = "Period 2",
                            PeriodNumber = 2
                        },
                        new
                        {
                            PeriodId = "3",
                            Name = "Period 3",
                            PeriodNumber = 3
                        },
                        new
                        {
                            PeriodId = "4",
                            Name = "Period 4",
                            PeriodNumber = 4
                        },
                        new
                        {
                            PeriodId = "5",
                            Name = "Period 5",
                            PeriodNumber = 5
                        },
                        new
                        {
                            PeriodId = "6",
                            Name = "Period 6",
                            PeriodNumber = 6
                        },
                        new
                        {
                            PeriodId = "7",
                            Name = "Period 7",
                            PeriodNumber = 7
                        },
                        new
                        {
                            PeriodId = "8",
                            Name = "Period 8",
                            PeriodNumber = 8
                        },
                        new
                        {
                            PeriodId = "9",
                            Name = "Period 9",
                            PeriodNumber = 9
                        });
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.StatusType", b =>
                {
                    b.Property<string>("StatusTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusTypeId");

                    b.ToTable("StatusTypes");

                    b.HasData(
                        new
                        {
                            StatusTypeId = "1",
                            Name = "Submitted"
                        },
                        new
                        {
                            StatusTypeId = "2",
                            Name = "Approved"
                        },
                        new
                        {
                            StatusTypeId = "3",
                            Name = "Denied"
                        },
                        new
                        {
                            StatusTypeId = "4",
                            Name = "Canceled"
                        });
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.SubJob", b =>
                {
                    b.Property<string>("SubJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AbsenceRequestId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("PeriodId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubJobId");

                    b.HasIndex("AbsenceRequestId");

                    b.HasIndex("CourseId");

                    b.HasIndex("PeriodId");

                    b.HasIndex("UserId");

                    b.ToTable("SubJobs");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CampusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PositionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CampusId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.AbsenceRequest", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.AbsenceType", "AbsenceType")
                        .WithMany("AbsenceRequests")
                        .HasForeignKey("AbsenceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.DurationType", "DurationType")
                        .WithMany("AbsenceRequests")
                        .HasForeignKey("DurationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.StatusType", "StatusType")
                        .WithMany("AbsenceRequests")
                        .HasForeignKey("StatusTypeId");

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", "User")
                        .WithMany("AbsenceRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.AbsenceRequestPeriod", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.AbsenceRequest", "AbsenceRequest")
                        .WithMany("AbsenceRequestPeriods")
                        .HasForeignKey("AbsenceRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Period", "Period")
                        .WithMany("AbsenceRequestPeriods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.Course", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Period", "Period")
                        .WithMany("Courses")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.CoveragePeriod", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Period", "Period")
                        .WithMany("CoveragePeriods")
                        .HasForeignKey("PeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", "User")
                        .WithOne("CoveragePeriod")
                        .HasForeignKey("AbsenceCoverageMS.Models.DomainModels.CoveragePeriod", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.SubJob", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.AbsenceRequest", "AbsenceRequest")
                        .WithMany("SubJobs")
                        .HasForeignKey("AbsenceRequestId");

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Period", null)
                        .WithMany("SubJobs")
                        .HasForeignKey("PeriodId");

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", "User")
                        .WithMany("SubJobs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AbsenceCoverageMS.Models.DomainModels.User", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.Campus", "Campus")
                        .WithMany("Users")
                        .HasForeignKey("CampusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AbsenceCoverageMS.Models.DomainModels.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
