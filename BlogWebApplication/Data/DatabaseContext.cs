using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





namespace BlogWebApplication.Data

{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext>options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=MEHMETCAN;Database=BlogWebApplication;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");

            //TrustServerCertificate=True; kısmını normal projede kaldır web app i güvenlik porblemlerine açık hala getirir, kendi bilgisayarındaki problem yüzünden koydun bunu connection string ine
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(

                new User
                {
                    Id= 1,
                    CreateDate= DateTime.Now,
                    IsActive= true,
                    Name="Admin",
                    Surname="Admin",
                    Password="123456",
                    UserName="Admin",
                    Email= "admin@blogwebapplication.net"
                }


                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
