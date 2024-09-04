using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; //DbContext

namespace MuffinSystemDemo.Models
{
    //2
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MuffinsDatabase") { }

        public DbSet<Orders> orders { get; set; }
        public DbSet<MuffinItems> items { get; set; }
    }
}