using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "DealerService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы DealerService.svc или DealerService.svc.cs в обозревателе решений и начните отладку.
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
                    dealer.Cars.Clear();
                    foreach (var car in updatedDealer.Cars)
                    {
                        dealer.Cars.Add(new Car(car.Id, car.Brand, car.Series, car.ReleaseYear, car.DoorNum, car.Color, car.BodyType));
                    }
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
                    dealer.Cars.Add(car);
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }

        public void deleteDealerCar(string dealerId, Car car)
        {
            List<Dealer> dealers = jsonManager.LoadDealersJson();
            foreach (var dealer in dealers)
            {
                if (dealer.Id == dealerId)
                {
                    foreach (var _car in dealer.Cars)
                    {
                        if (_car.Id == car.Id) dealer.Cars.Remove(car);
                    }
                }
            }
            jsonManager.WriteDealersJson(dealers);
        }
    }
}
