using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller
    {
        private readonly IRestaurantData db;

        public GreetingController(IRestaurantData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Create(restaurant);
                return RedirectToAction("Details", new { Id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = db.Get(Id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Update(restaurant);
                TempData["Message"] = "You have successfully saved the restaurant information!";
                return RedirectToAction("Details", new { Id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var model = db.Get(Id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, FormCollection formCollection)
        {
            db.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}