using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SepetIslemi.ExtensionMethods;
using SepetIslemi.Models;
using SepetIslemi.Models.Carts;
using SepetIslemi.Models.EntityFramework;
using SepetIslemi.Models.ViewModels;

namespace SepetIslemi.Controllers
{
    public class HomeController : Controller
    {
        NorthwindContext _db;

        public HomeController(NorthwindContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult ListMyProducts()
        {
            ListProductsViewModel model = new ListProductsViewModel
            {
                Products = _db.Products.Include("Category").ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult AddMyCart(int id)
        {
            MyCart myCart;

            if (HttpContext.Session.GetObject<MyCart>("cart") == null)
            {
                myCart = new MyCart();
            }
            else
            {
                myCart = HttpContext.Session.GetObject<MyCart>("cart");
            }

            Product product = _db.Products.Find(id);

            CartItem cartItem = new CartItem();

            cartItem.ID = product.ProductID;
            cartItem.Name = product.ProductName;
            cartItem.Price = product.UnitPrice;

            myCart.Add(cartItem);

            HttpContext.Session.SetObject("cart", myCart);

            return RedirectToAction("ListMyProducts");
        }

        [HttpGet]
        public IActionResult ListMyCartItems()
        {
            if (HttpContext.Session.GetObject<MyCart>("cart") != null)
            {
                MyCart myCart = HttpContext.Session.GetObject<MyCart>("cart");

                ListCartItemsViewModel model = new ListCartItemsViewModel
                {
                    CartItems = myCart.ListMyCartItems,
                    TotalPrice = myCart.TotalPrice
                };

                return View(model);
            }

            return RedirectToAction("ListMyProducts");
        }

        [HttpGet]
        public IActionResult DeleteMyCart(int id)
        {
            MyCart myCart = HttpContext.Session.GetObject<MyCart>("cart");

            myCart.Delete(id);

            HttpContext.Session.SetObject("cart", myCart);

            return RedirectToAction("ListMyCartItems");
        }
    }
}