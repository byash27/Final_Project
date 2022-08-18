using FinalP.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FinalP.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StartupInfo> StartupInfos { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


    }
}
