using Microsoft.EntityFrameworkCore;
using SSP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSP.WebAPI.DbContexts
{
    public class SSPDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<JobStatus> jobStatuses { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public SSPDbContext(DbContextOptions<SSPDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Client>()
                .ToTable("clients", schema: "base")
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Client);

            modelBuilder.
                Entity<Job>()
                .ToTable("jobs", schema: "base")
                .HasOne(x => x.Treatment)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.TreatmentId);

            modelBuilder.
                Entity<Job>()
                .ToTable("jobs", schema: "base")
                .HasOne(x => x.Booking)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.BookingId);

            modelBuilder.
                Entity<Job>()
                .ToTable("jobs", schema: "base")
                .HasOne(x => x.JobStatus)
                .WithMany(x => x.Jobs)
                .HasForeignKey(x => x.JobStatusId);

            modelBuilder.
                Entity<Treatment>()
                .ToTable("treatments", schema: "base")
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Treatment);

            modelBuilder.
                Entity<JobStatus>()
                .ToTable("job_statuses", schema: "base")
                .HasMany(x => x.Jobs)
                .WithOne(x => x.JobStatus);

            modelBuilder.
                Entity<Booking>()
                .ToTable("bookings", schema: "base")
                .HasMany(x => x.Jobs)
                .WithOne(x => x.Booking);

            modelBuilder.
                Entity<Booking>()
                .ToTable("bookings", schema: "base")
                .HasOne(x => x.Client)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.ClientId);

        }
    }
}
