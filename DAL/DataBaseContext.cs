using Microsoft.EntityFrameworkCore;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=MEHMETCAN;Database=BlogWebApplication;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

           
        }
      
    }
}
