using System;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewsModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> FavCar { get; set; }
    }
}
