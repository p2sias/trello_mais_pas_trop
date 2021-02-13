using Microsoft.EntityFrameworkCore;
using trello_mais_pas_trop.DAL.Models;

namespace trello_mais_pas_trop.DAL
{
    public class TrelloMptContext : DbContext
    {
        public TrelloMptContext(DbContextOptions<TrelloMptContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskUser> TaskUser {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskUser>()
                .HasKey(tu => new { tu.TaskId, tu.UserId });
            modelBuilder.Entity<TaskUser>()
                .HasOne(tu => tu.User)
                .WithMany(user => user.TaskUser)
                .HasForeignKey(tu => tu.UserId);
            modelBuilder.Entity<TaskUser>()
                .HasOne(tu => tu.Task)
                .WithMany(task => task.TaskUser)
                .HasForeignKey(tu => tu.TaskId);
        }
    }
}
