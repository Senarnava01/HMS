using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Models
{
    public class HMSDbContext : DbContext
    {
        public HMSDbContext(DbContextOptions options) : base(options)
        { }
        public HMSDbContext()
        {

        }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<room> rooms { get; set; }
        public virtual DbSet<booking> bookings { get; set; }
    }
}