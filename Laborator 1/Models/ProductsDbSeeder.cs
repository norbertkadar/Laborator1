using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator_1.Models
{
    public class ProductsDbSeeder
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            context.Products.AddRange(
                new Product
                {
                    Id = 1,
                    Name = "revista",
                    Description = "magazin",
                    Category = "tech",
                    Price = 33
                },
                new Product
                {
                    Id = 2,
                    Name = "stilus",
                    Description = "something",
                    Category = "new",
                    Price = 335
                });
            context.SaveChanges();
        }
    }
}
