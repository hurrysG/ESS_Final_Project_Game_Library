using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FINALPROJ.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FINALPROJ.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users{get; set;}
        public DbSet<Game> Games{get; set;}
        public DbSet<Developer> Developers {get;set;}
        public DbSet<Publisher> Publishers {get;set;}

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("FileName=MyDB.db");
        }
    }
}