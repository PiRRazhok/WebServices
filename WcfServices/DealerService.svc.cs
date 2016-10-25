using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    public class DealerService : IDealerService
    {
        // GET

        public List<Dealer> getAllDealers()
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            return dealers;
        }

        public Dealer getDealer(string dealerId)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId) return dealer;
            }
            return new Dealer();
        }

        // PUT

        public void addDealer(Dealer dealer)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            int count = dealers.Count;
            dealer.Id = "" + count;
            dealers.Add(dealer);
            jsonManager.WriteDealersJson(dealers);
        }

        // UPDATE

        public void updateDealer(Dealer updatedDealer)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == updatedDealer.Id)
                {
                    dealer.Name = updatedDealer.Name;
                    dealer.Email = updatedDealer.Email;
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }

        //DELETE

        public void deleteDealer(string dealerId)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId)
                {
                    dealers.Remove(dealer);
                    break;
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }

        // DEALER CARS

        public List<Car> getDealerCars(string dealerId)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId) return dealer.Cars;
            }
            return new List<Car>();
        }

        public void addDealerCar(string dealerId, Car car)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId)
                {
                    if (dealer.Cars == null)
                    {
                        dealer.Cars = new List<Car>();
                    }
                    dealer.Cars.Add(car);
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }

        public void deleteDealerCar(string dealerId, string carId)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId)
                {
                    foreach (var car in dealer.Cars)
                    {
                        if (car.Id == carId) dealer.Cars.Remove(car);
                    }
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }
    }
}
