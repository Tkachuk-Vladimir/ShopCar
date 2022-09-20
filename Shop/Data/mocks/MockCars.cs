using System;
using Shop.Data.interfaces;
using System.Collections.Generic;
using Shop.Data.Models;
using System.Linq;

namespace Shop.Data.mocks
{
    public class CarsRepository : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        name = "Tesla",
                        shortDesc = "Fast car",
                        longDesc = "Butiful car,fast, quiet car",
                        img = "/img/car.png",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                   /* new Car
                    {
                        name = "Ford fiest",
                        shortDesc = "Quiet and ",
                        longDesc = "A comfortable car for city live",
                        img = "/img/car.png",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                   */
                };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
