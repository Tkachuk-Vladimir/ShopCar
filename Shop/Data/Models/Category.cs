using System;
using System.Collections.Generic;

namespace Shop.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { get; set; }
        public List<Car> cars { set; get; }
    }
}
