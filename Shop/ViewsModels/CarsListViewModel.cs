using System;
using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewsModels
{
    public class CarsListViewModel
    {
        public IEnumerable<Car> AllCars { get; set; }
        public string CurrentCategory { get; set; }
    }
}
