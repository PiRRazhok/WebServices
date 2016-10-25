using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface IDealerService
    {
        // GET

        [OperationContract]
        List<Dealer> getAllDealers();

        [OperationContract]
        Dealer getDealer(string dealerId);

        // PUT

        [OperationContract]
        void addDealer(Dealer dealer);

        // UPDATE

        [OperationContract]
        void updateDealer(Dealer updatedDealer);

        //DELETE

        [OperationContract]
        void deleteDealer(string dealerId);

        // DEALER CARS

        [OperationContract]
        List<Car> getDealerCars(string dealerId);

        [OperationContract]
        void addDealerCar(string dealerId, Car car);

        [OperationContract]
        void deleteDealerCar(string dealerId, string carId);
    }
}
