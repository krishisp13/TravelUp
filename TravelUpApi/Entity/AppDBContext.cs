using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelUpApi.Models;

namespace TravelUpApi.Entity
{
	public class AppDBContext : DbContext
    {
        public AppDBContext() : base("ProductDbConnection") // from Web.config
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
