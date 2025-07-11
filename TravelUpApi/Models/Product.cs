using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelUpApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
    }
}