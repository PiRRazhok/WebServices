using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.CarServiceReference;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Index()
        {
            using (var client = new CarServiceClient())
            {
                CarServiceReference.Car[] carsData = client.getAllCars();
                List<CarModel> cars = new List<CarModel>();
                foreach (var car in carsData)
                {
                    cars.Add(new CarModel(car.Brand, car.Series, car.ReleaseYear, car.DoorNum, car.Color, car.BodyType));
                }
                ViewBag.cars = cars;
                return View((IEnumerable<CarModel>)cars);
            }
        }

        // GET: Cars/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new CarServiceClient())
            {
                CarServiceReference.Car car = client.getCar(id);
                ViewBag.car = car;
                return View(new CarModel(car.Brand, car.Series, car.ReleaseYear, car.DoorNum, car.Color, car.BodyType));
            }
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string brand = collection["Brand"].ToString();
                string series = collection["Series"].ToString();
                int releaseYear = Int32.Parse(collection["ReleaseYear"].ToString());
                int doorNum = Int32.Parse(collection["DoorNum"].ToString());
                string color = collection["Color"].ToString();
                string bodyType = collection["BodyType"].ToString();

                using (var client = new CarServiceClient())
                {
                    CarServiceReference.Car newCar = new CarServiceReference.Car(brand, series, releaseYear, doorNum, color, bodyType);
                    client.addCar(newCar);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new CarServiceClient())
            {
                CarServiceReference.Car car = client.getCar(id.ToString());
                ViewBag.car = car;
                return View(new CarModel(car.Brand, car.Series, car.ReleaseYear, car.DoorNum, car.Color, car.BodyType));
            }
        }

        // POST: Cars/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string brand = collection["Brand"].ToString();
                string series = collection["Series"].ToString();
                int releaseYear = Int32.Parse(collection["ReleaseYear"].ToString());
                int doorNum = Int32.Parse(collection["DoorNum"].ToString());
                string color = collection["Color"].ToString();
                string bodyType = collection["BodyType"].ToString();

                using (var client = new CarServiceClient())
                {
                    CarServiceReference.Car newCar = new CarServiceReference.Car(brand, series, releaseYear, doorNum, color, bodyType);
                    client.updateCar(newCar);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(string id)
        {
            using (var client = new CarServiceClient())
            {
                CarServiceReference.Car car = client.getCar(id);
                ViewBag.car = car;
                return View(new CarModel(car.Brand, car.Series, car.ReleaseYear, car.DoorNum, car.Color, car.BodyType));
            }
        }

        // POST: Cars/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                using (var client = new CarServiceClient())
                {
                    CarServiceReference.Car car = client.getCar(id);
                    client.deleteCar(car.Id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
