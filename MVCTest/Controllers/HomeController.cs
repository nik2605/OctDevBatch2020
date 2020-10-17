using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTest.Data;
using MVCTest.Models;


namespace MVCTest.Controllers
{
    [Route("api")]
    public class HomeController : Controller 
    {
        

        public ActionResult Index()
        {

            User user = new User(5);

            var status = Common.UserStatus.Active;


            UserProfile profile = new UserProfile();

            profile.UserId = 1;

            profile.Address = "Hamilton";

            profile.FirstName = "Nik";

            profile.LastName = "Adhaduk";

            profile.Department = "IT";

            return View(profile);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            UserProfile profile = new UserProfile();

            profile.UserId = 1;

            profile.Address = "Hamilton";

            profile.FirstName = "Nik";

            profile.LastName = "Adhaduk";

            profile.Department = "IT";

            return View(profile);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult CityFinder(string prefix)
        {
            List<City> cities = new List<City>()
            {
                new City(){Id = 1, Name = "Junagadh"},
                new City(){Id = 2, Name = "Ahmedabad"},
                new City(){Id = 3, Name = "Surat"},
                new City(){Id = 4, Name = "Somnath"},
                new City(){Id = 5, Name = "Hamilton"},
                new City(){Id = 5, Name = "Delhi"},
                new City(){Id = 5, Name = "New Delhi"},
            };

            var cityList = cities.Where(a => a.Name.ToLower().Contains(prefix.ToLower())).Select(b => b.Name);

            return Json(cityList, JsonRequestBehavior.AllowGet);
        }


    }

    

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}