using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Repository.Models
{
    public class EnvironmentContext : DbContext
    {
        public EnvironmentContext(DbContextOptions<EnvironmentContext> options)
            : base(options)
        { }

        public DbSet<Environment> Environments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EnvironmentUser> EnvironmentUsers { get; set; }
        public DbSet<EnvironmentUsingStatus> EnvironmentUsEnvironmentUsingStatuses { get; set; }
    }

    public class Environment
    {
        public int EnvironmentId { get; set; }

        public string EnvironmentName { get; set; }

        public User user { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }
    }

    public class EnvironmentUsingStatus
    {
        public int EnvironmentUsingStatusId { get; set; }
        public string EnvironmentUsingStatusName { get; set; }
    }

    public class EnvironmentUser
    {
        public int EnvironmentUserId { get; set; }
        public int EnvironmentId { get; set; }
        public Environment Environment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
