using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using week11.Models;

namespace week11.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<student> students{ get; set; }
        public DbSet<teacher> teachers{ get; set; }
        public DbSet<manager> managers{ get; set; }
        public DbSet<x> xx{ get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
