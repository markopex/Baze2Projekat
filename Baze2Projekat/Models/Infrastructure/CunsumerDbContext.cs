using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Infrastructure
{
    public class ConsumerDbContext : DbContext
    {
        public ConsumerDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fix>().HasNoKey();
            modelBuilder.Entity<BorrowsEquipment>().HasNoKey();
            modelBuilder.Entity<Bill>().HasOne(t => t.ConsumerMeter)
                                       .WithMany(t => t.Bills)
                                       .HasForeignKey(d => d.MeterId)
                                       .IsRequired();
        }

        public virtual DbSet<Electrician> Electricians { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }
        public virtual DbSet<Fault> Faults { get; set; }
        public virtual DbSet<Fix> Fixes { get; set; }
        public virtual DbSet<Meter> Meters { get; set; }
        public virtual DbSet<SmartMeter> SmartMeters { get; set; }
        public virtual DbSet<AnalogMeter> AnalogMeters { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<AnalogMeterReading> AnalogMeterReadings { set; get; }
        public virtual DbSet<BorrowsEquipment> BorrowsEquipments { set; get; }
        public virtual DbSet<Bill> Bills { set; get; }


    }
}
