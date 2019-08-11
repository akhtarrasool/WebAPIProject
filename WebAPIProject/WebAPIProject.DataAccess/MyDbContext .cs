using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WebAPIProject.Entities;

namespace WebAPIProject.DataAccess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Training> Trainings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });


            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<Training>().ToTable("Training", "test");
            modelBuilder.Entity<Training>(entity =>
            {
                entity.HasKey(e => e.TrainingId);
                entity.HasIndex(e => e.TrainingName);
                entity.Property(e => e.StartDate);
                entity.Property(e => e.EndDate);
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
