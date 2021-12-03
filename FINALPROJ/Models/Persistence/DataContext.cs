using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FINALPROJ.Models
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users{get; set;}
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("FileName=MyDB.db");
        }
    }
}