using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1
{
    public partial class FlightsContext : DbContext
    {
        public FlightsContext()
        {
        }

        public FlightsContext(DbContextOptions<FlightsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightSchedule> FlightSchedule { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Passengers> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=Flights;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlightSchedule>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Flight_schedule");

                entity.Property(e => e.DepartureDate)
                    .HasColumnName("Departure_date")
                    .HasColumnType("date");

                entity.Property(e => e.DepartureNumber).HasColumnName("Departure_number");

                entity.Property(e => e.DepartureTime).HasColumnName("Departure_time");

                entity.Property(e => e.FlightNumber).HasColumnName("Flight_number");

                entity.Property(e => e.IdDeparture).HasColumnName("ID_departure");

                entity.HasOne(d => d.FlightNumberNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FlightNumber)
                    .HasConstraintName("FK__Flight_sc__Fligh__3B75D760");

                entity.HasOne(d => d.IdDepartureNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdDeparture)
                    .HasConstraintName("FK__Flight_sc__ID_de__3A81B327");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightNumber)
                    .HasName("PK__Flights__5DD08D782100931E");

                entity.Property(e => e.FlightNumber)
                    .HasColumnName("Flight_number")
                    .ValueGeneratedNever();

                entity.Property(e => e.AircraftType)
                    .IsRequired()
                    .HasColumnName("Aircraft_type")
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Airlines)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Froms)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LengthKm).HasColumnName("Length_km");

                entity.Property(e => e.TimeInPath).HasColumnName("Time_in_path");

                entity.Property(e => e.Wheres)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Passengers>(entity =>
            {
                entity.HasKey(e => e.IdDeparture)
                    .HasName("PK__Passenge__C5EDA826F58AA3E7");

                entity.Property(e => e.IdDeparture)
                    .HasColumnName("ID_departure")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPassenger).HasColumnName("ID_passenger");

                entity.Property(e => e.PassengerLastname)
                    .IsRequired()
                    .HasColumnName("Passenger_lastname")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PassengerName)
                    .IsRequired()
                    .HasColumnName("Passenger_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ServiceClass)
                    .IsRequired()
                    .HasColumnName("Service_class")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
