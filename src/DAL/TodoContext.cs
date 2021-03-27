using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }



        public TodoContext(DbContextOptions<TodoContext> config) : base(config)
        { }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Assignee>().HasData
            // (
            //     new Assignee {Id = 1, Name = "Mike"},
            //     new Assignee {Id = 1, Name = "Frank"},
            //     new Assignee {Id = 1, Name = "Kim"}
            // );

        }
    }
}