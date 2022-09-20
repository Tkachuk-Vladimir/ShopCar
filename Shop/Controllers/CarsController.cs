using System;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.Data.mocks;
using Microsoft.AspNetCore.Mvc;
using Shop.ViewsModels;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electric car")).OrderBy(i => i.id);
                    currCategory = "Electric car";
                }
                else
                {
                    if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                    {
                        cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Classic car")).OrderBy(i => i.id);
                        currCategory = "Classic car";
                    }
                }
            }
            
            CarsListViewModel carObj = new CarsListViewModel()
            {
                AllCars = cars,
                CurrentCategory = currCategory
            };

            return View(carObj);
        }
    }
}
