using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrcture.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options){

        }
        public DbSet<Userclass> Users { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Userclass>().ToTable("users");
        }
    }
}