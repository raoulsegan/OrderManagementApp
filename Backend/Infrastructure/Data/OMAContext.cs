using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {
        public OMAContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", ContactNumber = "041234789", Email = "john.doe@example.com" },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", ContactNumber = "0165775216", Email = "jane.smith@example.com" }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, CustomerId = 1, AddressLine1 = "123 Main St", AddressLine2 = "2nd floor", City = "Anytown", State = "CA", Country = "USA" },
                new Address { Id = 2, CustomerId = 2, AddressLine1 = "456 Elm St", AddressLine2 = "1st floor", City = "Othertown", State = "TX", Country = "USA" }
            );
             modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 1, OrderDate = new DateTime(2025, 10, 20), Description = "New Item", TotalAmount= 500, DepositAmount= 10, IsDelivery= true, Status= Core.Enums.Status.Pending, OrderNotes= "Please deliver between 5-6 PM", IsDeleted= false },
                new Order { Id = 2, CustomerId = 2, OrderDate = new DateTime(2025, 10, 21), Description = "Another Item", TotalAmount= 300, DepositAmount= 30, IsDelivery= false, Status= Core.Enums.Status.Completed, OrderNotes= "Leave at the front door", IsDeleted= false }
            );               
        }

    }
}