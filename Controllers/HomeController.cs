using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        // public Dojodachi StartNewGame(){
        //     SessionExtensions.clear;
        //     Dojodachi yourDojodachi = new Dojodachi();
        //     return yourDojodachi;
        // }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Energy") == null)
            {
                HttpContext.Session.SetInt32("Happiness", 20);
                HttpContext.Session.SetInt32("Fullness", 20);
                HttpContext.Session.SetInt32("Energy", 50);
                HttpContext.Session.SetInt32("Meals", 3);
                HttpContext.Session.SetInt32("Alive", 0);
            }
            ViewBag.happiness = HttpContext.Session.GetInt32("Happiness").Value;
            ViewBag.fullness = HttpContext.Session.GetInt32("Fullness").Value;
            ViewBag.energy = HttpContext.Session.GetInt32("Energy").Value;
            ViewBag.meals = HttpContext.Session.GetInt32("Meals").Value;
            ViewBag.alive = HttpContext.Session.GetInt32("Alive").Value;
            if (HttpContext.Session.GetString("Last") != null){
                ViewBag.last = HttpContext.Session.GetString("Last");
            }
            if (ViewBag.happiness >= 100 && ViewBag.fullness >= 100 && ViewBag.energy >= 100)
            {
                ViewBag.alive = 2;
            }
            else if (ViewBag.fullness <= 0 || ViewBag.happiness <= 0)
            {
                ViewBag.alive = 1;
            }
            return View("Index");
        }
        [HttpPost]
        [Route("Dojodachi")]
        public IActionResult Dojodachi(string dachiaction)
        {
        
            if (dachiaction == "restart") {
                HttpContext.Session.Clear();
                return RedirectToAction("Index");
            }
            if (HttpContext.Session.GetInt32("Alive") == 0)
            {
                System.Console.WriteLine("I'm so alive.");
                if (dachiaction == "feed")
                {
                    System.Console.WriteLine("I'm feeding");
                    System.Console.WriteLine("Meals: " + HttpContext.Session.GetInt32("Meals").Value);
                    if (HttpContext.Session.GetInt32("Meals").Value < 1)
                    {
                        return RedirectToAction("Index");
                    }
                    HttpContext.Session.SetInt32("Meals", (HttpContext.Session.GetInt32("Meals").Value - 1));
                    System.Console.WriteLine("Meals: " + HttpContext.Session.GetInt32("Meals").Value);

                    Random rnd = new Random();
                    int eaten = rnd.Next(5, 11);
                    Random satisfy = new Random();
                    int satisfied = satisfy.Next(1, 5);
                    if (satisfied != 1)
                    {
                        HttpContext.Session.SetInt32("Fullness", ((int)HttpContext.Session.GetInt32("Fullness") + eaten));
                        HttpContext.Session.SetString("Last", "Your Dojodachi enjoyed that meal! Meals - 1, Fullness + " + eaten);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Last", "Your Dojodachi thinks your cooking could improve.... Meals - 1, Fullness unchanged ");
                    }
                }
                if (dachiaction == "play")
                {
                    if (HttpContext.Session.GetInt32("Energy") < 5)
                    {
                        return RedirectToAction("Index");
                    }
                    HttpContext.Session.SetInt32("Energy", ((int)HttpContext.Session.GetInt32("Energy") - 5));
                    Random rnd = new Random();
                    int happy = rnd.Next(5, 11);
                    Random satisfy = new Random();
                    int satisfied = satisfy.Next(1, 5);
                    if (satisfied != 1)
                    {
                        HttpContext.Session.SetInt32("Happiness", ((int)HttpContext.Session.GetInt32("Happiness") + happy));
                        HttpContext.Session.SetString("Last", ("Your Dojodachi enjoyed playtime! Energy - 5, Happiness + " + happy));
                    }
                    else {
                        HttpContext.Session.SetString("Last", "Your Dojodachi thinks you're boring...sorry.. Energy - 5, Happiness unchanged");
                    }
                }
                if (dachiaction == "work")
                {
                    if (HttpContext.Session.GetInt32("Energy") < 5)
                    {
                        return RedirectToAction("Index");
                    }
                    HttpContext.Session.SetInt32("Energy", ((int)HttpContext.Session.GetInt32("Energy") - 5));
                    Random rnd = new Random();
                    int food = rnd.Next(1, 4);
                    HttpContext.Session.SetInt32("Meals", ((int)HttpContext.Session.GetInt32("Meals") + food));
                    HttpContext.Session.SetString("Last", ("Your Dojodachi went to work, yet wonders why work is necessary when Dojodachi is a pet.. Energy - 5, Meals + " + food));

                }
                if (dachiaction == "sleep")
                {
                    HttpContext.Session.SetInt32("Energy", ((int)HttpContext.Session.GetInt32("Energy") + 15));
                    HttpContext.Session.SetInt32("Happiness", ((int)HttpContext.Session.GetInt32("Happiness") - 5));
                    HttpContext.Session.SetInt32("Fullness", ((int)HttpContext.Session.GetInt32("Fullness") - 5));
                    HttpContext.Session.SetString("Last", "Your Dojodachi wonders what you do while they sleep.. Energy + 15, Happiness - 5, Fullness - 5");

                }
            }
            return RedirectToAction("Index");
        }
    }
}