using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICarService" в коде и файле конфигурации.
    [ServiceContract]
    public interface ICarService
    {
        // GET

        [OperationContract]
        List<Car> getAllCars();

        [OperationContract]
        Car getCar(string carId);

        // PUT

        [OperationContract]
        void addCar(Car car);

        // UPDATE

        [OperationContract]
        void updateCar(Car updatedCar);

        //DELETE

        [OperationContract]
        void deleteCar(string carId);
    }
}
