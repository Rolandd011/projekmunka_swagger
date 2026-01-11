using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Models;

namespace MyApp.Backend.Context
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // -------------------------
            // ROLES
            // -------------------------
            modelBuilder.Entity<Role>().HasData(
                  new Role { RoleId = 1, Name = "Admin" },
                  new Role { RoleId = 2, Name = "Support" },
                  new Role { RoleId = 3, Name = "User" }
              );

            // -------------------------
            // USERS
            // -------------------------
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = "hash1", RoleId = 1 },
                new User { Id = 2, Name = "Bob", Email = "bob@test.com", PasswordHash = "hash2", RoleId = 2 },
                new User { Id = 3, Name = "Charlie", Email = "charlie@test.com", PasswordHash = "hash3", RoleId = 3 }
            );


            // -------------------------
            // STATUS
            // -------------------------
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, Name = "Open" },
                new Status { StatusId = 2, Name = "In Progress" },
                new Status { StatusId = 3, Name = "Resolved" },
                new Status { StatusId = 4, Name = "Closed" }
            );

            // -------------------------
            // PRIORITY
            // -------------------------
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Low" },
                new Priority { Id = 2, Name = "Medium" },
                new Priority { Id = 3, Name = "High" },
                new Priority { Id = 4, Name = "Critical" }
            );

            // -------------------------
            // CATEGORY
            // -------------------------
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Hardware" },
                new Category { Id = 2, Name = "Software" },
                new Category { Id = 3, Name = "Network" },
                new Category { Id = 4, Name = "Other" }
            );

            // -------------------------
            // LOCATION
            // -------------------------
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Budapest" },
                new Location { Id = 2, Name = "Debrecen" },
                new Location { Id = 3, Name = "Szeged" },
                new Location { Id = 4, Name = "Győr" }
            );

            // -------------------------
            // ISSUES
            // -------------------------
            modelBuilder.Entity<Issue>().HasData(
                new Issue
                {
                    Id = 1,
                    Title = "Printer not working",
                    Description = "The office printer is jammed.",
                    Statusid = 1,
                    Priorityid = 2,
                    LocationId = 1,
                    CategoryId = 1,
                    Commentid = 1
                },
                new Issue
                {
                    Id = 2,
                    Title = "VPN connection fails",
                    Description = "Cannot connect to VPN from home.",
                    Statusid = 2,
                    Priorityid = 3,
                    LocationId = 3,
                    CategoryId = 3,
                    Commentid = 2
                }
            );

            // -------------------------
            // ACTIONS (Issue history)
            // -------------------------
            modelBuilder.Entity<UserAction>().HasData(
                new UserAction {Id = 1, IssueId = 1, UserId = 1, ActionText = "Login", Message = "User logged in", Date = DateTime.UtcNow },
                new UserAction {Id = 2, IssueId = 2, UserId = 2, ActionText = "Logout", Message = "User logged out", Date = DateTime.UtcNow }
             );

        }
    }
}
