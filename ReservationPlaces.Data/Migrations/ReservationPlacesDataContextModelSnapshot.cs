﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservationPlaces.Data;

namespace ReservationPlaces.Data.Migrations
{
    [DbContext(typeof(ReservationPlacesDataContext))]
    partial class ReservationPlacesDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReservationPlaces.Data.Models.AdminSettingsDAL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CloseHour");

                    b.Property<DateTime>("EndPeriod");

                    b.Property<int>("Interval");

                    b.Property<DateTime>("OpenHour");

                    b.Property<DateTime>("StartPeriod");

                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("AdminSettings");
                });

            modelBuilder.Entity("ReservationPlaces.Data.Models.ReservationDAL", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<DateTime>("EndVisit");

                    b.Property<DateTime>("StartVisit");

                    b.Property<string>("UserId")
                        .HasMaxLength(450);

                    b.HasKey("Id");

                    b.ToTable("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
