using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    public class CarService : ICarService
    {
        // GET

        public List<Car> getAllCars()
        {
            List<Car> cars = jsonManager.LoadCarsJson();
            return cars;
        }

        public Car getCar(string carId)
        {
            List<Car> cars = jsonManager.LoadCarsJson();
            foreach (var car in cars)
            {
                if (car.Id == carId) return car;
            }
            return new Car();
        }

        // PUT

        public void addCar(Car car)
        {
            List<Car> cars = jsonManager.LoadCarsJson();
            int count = cars.Count;
            car.Id = "" + count;
            cars.Add(car);
            jsonManager.WriteCarsJson(cars);
        }

        // UPDATE

        public void updateCar(Car updatedCar)
        {
            List<Car> cars = jsonManager.LoadCarsJson();
            foreach (var car in cars)
            {
                if (car.Id == updatedCar.Id)
                {
                    car.Brand = updatedCar.Brand;
                    car.Series = updatedCar.Series;
                    car.ReleaseYear = updatedCar.ReleaseYear;
                    car.DoorNum = updatedCar.DoorNum;
                    car.Color = updatedCar.Color;
                    car.BodyType = updatedCar.BodyType;
                }
            }
            jsonManager.WriteCarsJson(cars);
        }

        //DELETE

        public void deleteCar(string carId)
        {
            List<Car> cars = jsonManager.LoadCarsJson();
            foreach (var car in cars)
            {
                if (car.Id == carId)
                {
                    cars.Remove(car);
                    break;
                }
            }
            jsonManager.WriteCarsJson(cars);
        }

    }
}
