using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MainProject.Model
{
    public class TODOLIST:DbContext
    {
        string conString =System.Configuration.ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;

        public DbSet<TAB> TABs { get; set; }
        public DbSet<TASK> TASKs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAB>().ToTable("TAB");
            modelBuilder.Entity<TASK>().ToTable("TASK");

            base.OnModelCreating(modelBuilder);
        }
    }
}
