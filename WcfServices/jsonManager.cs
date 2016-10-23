using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WcfServices
{
    public class jsonManager
    {
        // Cars
        public static List<Car> LoadCarsJson()
        {
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~") + "/cars.json"))
            {
                List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(r.ReadToEnd());
                return cars;
            }
        }
        public static void WriteCarsJson(List<Car> data)
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~") + "/cars.json", JsonConvert.SerializeObject(data.ToArray()));
        }

        // Dealers
        public static List<Dealer> LoadDealersJson()
        {
            using (StreamReader r = new StreamReader(HttpContext.Current.Server.MapPath("~") + "/dealers.json"))
            {
                List<Dealer> dealers = JsonConvert.DeserializeObject<List<Dealer>>(r.ReadToEnd());
                return dealers;
            }
        }
        public static void WriteDealersJson(List<Dealer> data)
        {
            File.WriteAllText(HttpContext.Current.Server.MapPath("~") + "/dealers.json", JsonConvert.SerializeObject(data.ToArray()));
        }
    }
}