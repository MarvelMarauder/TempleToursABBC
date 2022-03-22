﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TempleToursABBC.Models;

namespace TempleToursABBC.Migrations
{
    [DbContext(typeof(AppointmentContext))]
    [Migration("20220322212951_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("TempleToursABBC.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupSize")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AppointmentId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("TempleToursABBC.Models.TimeSlot", b =>
                {
                    b.Property<int>("TimeSlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Slot")
                        .HasColumnType("TEXT");

                    b.HasKey("TimeSlotId");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            TimeSlotId = 1,
                            Available = false,
                            Slot = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeSlotId = 2,
                            Available = false,
                            Slot = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeSlotId = 3,
                            Available = false,
                            Slot = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TimeSlotId = 4,
                            Available = false,
                            Slot = new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TempleToursABBC.Models.Appointment", b =>
                {
                    b.HasOne("TempleToursABBC.Models.TimeSlot", "TimeSlot")
                        .WithMany()
                        .HasForeignKey("TimeSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}