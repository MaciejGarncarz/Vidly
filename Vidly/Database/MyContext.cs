using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Database
{
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}