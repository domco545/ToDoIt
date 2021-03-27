using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }


        public TodoContext(DbContextOptions<TodoContext> config) : base(config)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  Property mapping - NOT NULL

            //  Task
            modelBuilder.Entity<Task>()
                .Property(task => task.Description).IsRequired();

            modelBuilder.Entity<Task>()
                .Property(task => task.AssigneeId).IsRequired();
            modelBuilder.Entity<Task>()
                .Property(task => task.IsCompleted).IsRequired();

            //  Assignee
            modelBuilder.Entity<Assignee>()
                .Property(assignee => assignee.Name).IsRequired();


            //  unique assignee name
            modelBuilder.Entity<Assignee>()
                .HasAlternateKey(assignee => assignee.Name);


            //  Relationships

            modelBuilder.Entity<Task>()
                .HasOne(task => task.Assignee)
                .WithMany(assignee => assignee.Tasks);


            // modelBuilder.Entity<Assignee>().HasData
            // (
            //     new Assignee {Id = 1, Name = "Mike"},
            //     new Assignee {Id = 1, Name = "Frank"},
            //     new Assignee {Id = 1, Name = "Kim"}
            // );
        }
    }
}