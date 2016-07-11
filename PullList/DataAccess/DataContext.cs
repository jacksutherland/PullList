using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PullList.Models;

namespace PullList.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Pull> Pulls { get; set; }
    }
}