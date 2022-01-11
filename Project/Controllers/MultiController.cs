using System;
using System.Collections.Generic;
using System.Dynamic;
using Project.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    public class MultiController : Controller
    {
        // GET: Multi
        /* public ActionResult Index()
         {

             dynamic mymodel = new ExpandoObject();
             mymodel.storelist = GetStores();
             mymodel.userlist  = GetUsers();
             return View(mymodel);
         }*/
        private Entities1 db = new Entities1();

        public ViewResult Index(string sortOrder, string searchString)
        {

            ViewBag.BrandSortParm = String.IsNullOrEmpty(sortOrder) ? "Brand_desc" : "";

            var store = from p in db.Stores
                        select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                store = store.Where(p => p.name.ToUpper().Contains(searchString.ToUpper()));

            }

            /* switch (sortOrder)
             {
                 case "Brand_desc":
                     phone = phone.OrderByDescending(p => p.brand);
                     break;
                 default:
                     phone = phone.OrderBy(p => p.product_id);
                     break;
             }*/

            return View(store);
        }

        //List
        public List<Store> GetStores()
        {
            Entities1 db = new Entities1();
            List<Store> LStore = db.Stores.ToList();
            return LStore;
        }

        public List<User> GetUsers()
        {
            Entities1 db = new Entities1();
            List<User> LUser = db.Users.ToList();
            return LUser;
        }
    }
}