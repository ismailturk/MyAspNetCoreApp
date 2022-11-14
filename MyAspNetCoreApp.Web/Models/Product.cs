using System;
using System.Collections.Generic;

namespace MyAspNetCoreApp.Web
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Color { get; set; }

        public bool isPublish { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
