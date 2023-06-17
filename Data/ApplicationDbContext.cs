using System;
using CoreTravel.Models;

namespace CoreTravel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }

        public DbSet<Token>? Tokens { get; set; }


    }


}

