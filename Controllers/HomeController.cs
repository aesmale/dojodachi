using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        Dojodachi yourDojodachi = new Dojodachi();
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            HttpContext.Session.SetInt32("DachiHappiness", yourDojodachi.happiness);
            HttpContext.Session.SetInt32("DachiFullness", yourDojodachi.fullness);
            HttpContext.Session.SetInt32("DachiEnergy", yourDojodachi.energy);
            HttpContext.Session.SetInt32("DachiMeals", yourDojodachi.meals);
            HttpContext.Session.SetInt32("DachiAlive", yourDojodachi.alive);
            ViewBag.happiness = HttpContext.Session.GetInt32("DachiHappiness");
            ViewBag.fullness = HttpContext.Session.GetInt32("DachiFullness");
            ViewBag.energy = HttpContext.Session.GetInt32("DachiEnergy");
            ViewBag.meals = HttpContext.Session.GetInt32("DachiMeals");
            ViewBag.alive = HttpContext.Session.GetInt32("DachiAlive");
            System.Console.WriteLine("***************"+yourDojodachi.fullness+"***************" + yourDojodachi.meals);
            return View("Index");
        }
        [HttpPost]
        [Route("Dojodachi")]
        public IActionResult Dojodachi(string dachiaction)
        {
            Console.WriteLine("THE ACTION WASSSS" + dachiaction);
            System.Console.WriteLine(yourDojodachi.alive);
            if (yourDojodachi.alive == 0)
            {
                if (dachiaction == "feed")
                {
                    yourDojodachi.Feed();
                    System.Console.WriteLine("***************"+yourDojodachi.fullness+"***************" + yourDojodachi.meals);
                }
                if (dachiaction == "play")
                {
                    yourDojodachi.Play();
                }
                if (dachiaction == "work")
                {
                    yourDojodachi.Work();
                }
                if (dachiaction == "sleep")
                {
                    yourDojodachi.Sleep();
                }
            }
            return View("Index");
        }
    }
}