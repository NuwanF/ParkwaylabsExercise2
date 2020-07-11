using Microsoft.EntityFrameworkCore;
using ParkwaylabsExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Data
{
    public class DevTeamDBContext : DbContext
    {
        public DevTeamDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Developer_TechLead>().HasKey(q => new
            {
                q.DeveloperId,
                q.TechLeadId
            });

            builder.Entity<Developer_Technology>().HasKey(q => new
            {
                q.DeveloperId,
                q.TechnologyId
            });

            builder.Entity<TechLead_Technology>().HasKey(q => new
            {
                q.TechLeadId,
                q.TechnologyId
            });
        }
        public DbSet<Developer> Developer { get; set; }
        public DbSet<TechLead> TechLead { get; set; }
        public DbSet<Technology> Technology { get; set; }
        public DbSet<Developer_TechLead> Developer_TechLead { get; set; }
        public DbSet<Developer_Technology> Developer_Technology { get; set; }
        public DbSet<TechLead_Technology> TechLead_Technology { get; set; }
    }
}
