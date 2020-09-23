using System;
using Microsoft.EntityFrameworkCore;
using VirtuSystemsApp.DB.Models;

namespace VirtuSystemsApp.DB
{
    public class VirtuSystemsDbContex : DbContext
    {
        public VirtuSystemsDbContex()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=VirtuSystemsDB;Integrated Security=True;");
        }
    }
}
