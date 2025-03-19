﻿// <auto-generated />
using System;
using ES2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250319165218_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ES2.Data.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActivityDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("activitydate");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("activities", "public");
                });

            modelBuilder.Entity("ES2.Data.ActivityRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("integer")
                        .HasColumnName("activityid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("RegistrationId")
                        .HasColumnType("integer")
                        .HasColumnName("registrationid");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("activityregistrations", "public");
                });

            modelBuilder.Entity("ES2.Data.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("Category")
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("eventdate");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("OrganizerId")
                        .HasColumnType("integer")
                        .HasColumnName("organizerid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("OrganizerId");

                    b.ToTable("events", "public");
                });

            modelBuilder.Entity("ES2.Data.EventTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("integer")
                        .HasColumnName("quantityavailable");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tickettype");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("eventtickets", "public");
                });

            modelBuilder.Entity("ES2.Data.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("feedback", "public");
                });

            modelBuilder.Entity("ES2.Data.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer")
                        .HasColumnName("senderid");

                    b.Property<DateTime>("SentAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sentat")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("SenderId");

                    b.ToTable("messages", "public");
                });

            modelBuilder.Entity("ES2.Data.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanCreateEvents")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("cancreateevents");

                    b.Property<bool>("CanManageUsers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("canmanageusers");

                    b.Property<bool>("CanViewReports")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("canviewreports");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("permissions", "public");
                });

            modelBuilder.Entity("ES2.Data.Registration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("registrationdate")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Active")
                        .HasColumnName("status");

                    b.Property<int>("TicketId")
                        .HasColumnType("integer")
                        .HasColumnName("ticketid");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserId");

                    b.ToTable("registrations", "public");
                });

            modelBuilder.Entity("ES2.Data.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("integer")
                        .HasColumnName("eventid");

                    b.Property<string>("Feedback")
                        .HasColumnType("text")
                        .HasColumnName("feedback");

                    b.Property<DateTime>("GeneratedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("generatedat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("numeric")
                        .HasColumnName("revenue");

                    b.Property<int?>("TotalParticipants")
                        .HasColumnType("integer")
                        .HasColumnName("totalparticipants");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("reports", "public");
                });

            modelBuilder.Entity("ES2.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phonenumber");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updatedat")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("usertype");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "public");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "public");
                });

            modelBuilder.Entity("ES2.Data.Activity", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ES2.Data.ActivityRegistration", b =>
                {
                    b.HasOne("ES2.Data.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.Registration", "Registration")
                        .WithMany()
                        .HasForeignKey("RegistrationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Registration");
                });

            modelBuilder.Entity("ES2.Data.Event", b =>
                {
                    b.HasOne("ES2.Data.User", "Organizer")
                        .WithMany()
                        .HasForeignKey("OrganizerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizer");
                });

            modelBuilder.Entity("ES2.Data.EventTicket", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ES2.Data.Feedback", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ES2.Data.Message", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ES2.Data.Permission", b =>
                {
                    b.HasOne("ES2.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ES2.Data.Registration", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.EventTicket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ES2.Data.Report", b =>
                {
                    b.HasOne("ES2.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("ES2.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("ES2.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ES2.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("ES2.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
