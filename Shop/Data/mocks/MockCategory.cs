using System;
using Shop.Data.interfaces;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category {categoryName = "Electric car", desc = "Moder mode of transport"},
                    new Category {categoryName = "Classic car", desc = "Car of dvs "}
                };
            }
        }
    }
}
