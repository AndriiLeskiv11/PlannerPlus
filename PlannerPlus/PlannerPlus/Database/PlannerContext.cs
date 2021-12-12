using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlannerPlus.Models;

namespace PlannerPlus.Database  
{
    public class PlannerContext : DbContext
    {
        public DbSet<Master> Masters { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public PlannerContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Master>()
                .HasMany(m => m.Services)
                .WithMany(s => s.Masters)
                .UsingEntity(e => e.ToTable("MasterServices"));
        }
    }
}
