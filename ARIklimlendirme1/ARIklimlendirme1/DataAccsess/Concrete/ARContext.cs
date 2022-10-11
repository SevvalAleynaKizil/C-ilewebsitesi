using DataAccsess.Mapping;
using DataAccsess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Concrete
{
    public class ARContext : DbContext
    {
        public DbSet<Campaings> Campaigns { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Referance> Referance { get; set; }
        public DbSet<Ministration> Ministration { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2JCJJ20\SQLEXPRESS;Database=AriklimlendirmeDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CampaingsMap());
            modelBuilder.ApplyConfiguration(new InteractionsMap());
            modelBuilder.ApplyConfiguration(new ReferanceMap());
            modelBuilder.ApplyConfiguration(new MinistrationMap());
            modelBuilder.ApplyConfiguration(new UsersMap());

        }
    }
}
