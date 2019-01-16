using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IRestaurantData _restauranData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restauranData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restauranData.GetAll();
            model.CurrentMessagge = _greeter.GetMessageOfTheDay();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restauranData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant = _restauranData.Add(newRestaurant);
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }

    }
}
