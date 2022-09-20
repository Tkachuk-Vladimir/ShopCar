using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrder allOrder;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrder allOrder, ShopCart shopCart)
        {
            this.allOrder = allOrder;
            this.shopCart = shopCart;
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();

            if(shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You do not have product in cart");
            }

            if (ModelState.IsValid)
            {
                allOrder.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View();
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order complete";
            return View();
        }
    }
}
