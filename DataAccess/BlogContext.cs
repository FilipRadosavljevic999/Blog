using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BlogContext: DbContext
    {
        public BlogContext() { }
        public BlogContext(DbContextOptions opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().Property(x => x.Username).IsRequired();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogContext).Assembly);
          

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Data Source=DESKTOP-ADVVOD4\SQLEXPRESS01;Initial Catalog=ASPProject;Integrated Security=True
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-ADVVOD4\SQLEXPRESS01;Initial Catalog=ASPProject;Integrated Security=True;TrustServerCertificate=true");
           // base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryPost> CategoriesPost { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

    }
}
