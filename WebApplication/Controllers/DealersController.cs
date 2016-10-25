using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.DealerServiceReference;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DealersController : Controller
    {
        // GET: Dealer
        public ActionResult Index()
        {
            using (var client = new DealerServiceClient())
            {
                Dealer[] dealersData = client.getAllDealers();
                List<DealerModel> dealers = new List<DealerModel>();
                foreach (var dealer in dealersData)
                {
                    dealers.Add(new DealerModel(dealer.Id, dealer.Name, dealer.Email, dealer.Cars));
                }
                return View((IEnumerable<DealerModel>)dealers);
            }
        }

        // GET: Dealer/Details/5
        public ActionResult Details(string id)
        {
            using (var client = new DealerServiceClient())
            {
                Dealer dealer = client.getDealer(id);
                ViewBag.dealer = dealer;
                return View(new DealerModel(dealer.Id, dealer.Name, dealer.Email, dealer.Cars));
            }
        }

        // GET: Dealer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dealer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string name = collection["Name"].ToString();
                string email = collection["Email"].ToString();

                using (var client = new DealerServiceClient())
                {
                    Dealer newDealer = new Dealer(name, email);
                    client.addDealer(newDealer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Edit/5
        public ActionResult Edit(string id)
        {
            using (var client = new DealerServiceClient())
            {
                Dealer dealer = client.getDealer(id);
                ViewBag.dealer = dealer;
                DealerModel editingDealer = new DealerModel(dealer.Id, dealer.Name, dealer.Email, dealer.Cars);
                return View(editingDealer);
            }
        }

        // POST: Dealer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                string name = collection["Name"].ToString();
                string email = collection["Email"].ToString();

                using (var client = new DealerServiceClient())
                {
                    Dealer newDealer = new Dealer(id, name, email);
                    client.updateDealer(newDealer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dealer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dealer/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                using (var client = new DealerServiceClient())
                {
                    Dealer dealer = client.getDealer(id);
                    client.deleteDealer(dealer.Id);
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
