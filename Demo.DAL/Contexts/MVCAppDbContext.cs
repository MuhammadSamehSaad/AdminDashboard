using Demo.DAL.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts
{
    public class MVCAppDbContext:IdentityDbContext<ApplicationUser>
    {
        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //Apply Any Class Implement IEntityTypeConfiguration Interface
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }


        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }

        //public DbSet<IdentityRole> Roles { get; set; }


    }
}
