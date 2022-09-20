using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AddRange(
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Fast car",
                        longDesc = "Butiful car,fast, quiet car",
                        img = "/img/car.png",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Electric car"]
                    },
                    new Car
                    {
                        name = "Ford fiest",
                        shortDesc = "Quiet and ",
                        longDesc = "A comfortable car for city live",
                        img = "/img/car.png",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Classic car"]
                    }
                );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category {categoryName = "Electric car", desc = "Moder mode of transport"},
                        new Category {categoryName = "Classic car", desc = "Car of dvs "}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        } 

    }
}
