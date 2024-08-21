using CEM_TUT.Data;
using CEM_TUT.Interfaces;
using CEM_TUT.Models;
using CEM_TUT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.RulesetToEditorconfig;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace CEM_TUT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;

        private readonly ICSATCalculator _calculator;
        public HomeController(ILogger<HomeController> logger,AppDbContext context,ICSATCalculator calculator)
        {
            _logger = logger;

            _context = context;

            _calculator = calculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password) { 
        

            var user  = _context.servicesProviders.FirstOrDefault( u  => u.username == username && u.password == password);


            if(user != null) {

                HttpContext.Session.SetString("username", user.username);
                HttpContext.Session.SetString("providerId",user.providerId.ToString());
                return RedirectToAction("Dashboard");
            }else
            {

                ViewBag.ErrorMessage = "Invalid uusername";
                return View();
            }

        }
        public IActionResult Dashboard()
        {

            string servceName = "SMS";
            var username = HttpContext.Session.GetString("username");

            Models.ServiceProvider provider =  _context.servicesProviders.FirstOrDefault(u => u.username == username);

            List<int> ratingsSMS = _context.feedbacks.Where(f => f.serviceName == "SMS").Select(f => f.rating).ToList();

            List<int> ratingsSuffer = _context.feedbacks.Where(f => f.serviceName == "NIGHT SUFFER").Select(f => f.rating).ToList();

            List<int> ratingsAllNetworkMinutes = _context.feedbacks.Where(f => f.serviceName == "ALL NETWORK MINUTES").Select(f => f.rating).ToList();

            List<int> ratingsAllNetworkData = _context.feedbacks.Where(f => f.serviceName == "All NETWORK DATA").Select(f => f.rating).ToList();

            List<GeoAlert> alerts = _context.geoalerts.ToList();

            // Happay Customers

            List<int> happyRatingsSMS = _context.feedbacks.Where(f => f.serviceName == "SMS" && f.rating > 5).Select(f => f.rating).ToList();
            List<int> happyNightSuffer = _context.feedbacks.Where(f => f.serviceName == "NIGHT SUFFER" && f.rating > 5).Select(f => f.rating).ToList();
            List<int> happyAllNetwork = _context.feedbacks.Where(f => f.serviceName == "ALL NETWORK MINUTES" && f.rating > 5).Select(f => f.rating).ToList();
            List<int> happyData = _context.feedbacks.Where(f => f.serviceName == "All NETWORK DATA" && f.rating > 5).Select(f => f.rating).ToList();

            //Unhappy customers

            List<int> unhappyRatingsSMS = _context.feedbacks.Where(f => f.serviceName == "SMS" && f.rating < 6).Select(f => f.rating).ToList();
            List<int> unhappyNightSuffer = _context.feedbacks.Where(f => f.serviceName == "NIGHT SUFFER" && f.rating < 6).Select(f => f.rating).ToList();
            List<int> unhappyAllNetwork = _context.feedbacks.Where(f => f.serviceName == "ALL NETWORK MINUTES" && f.rating < 6).Select(f => f.rating).ToList();
            List<int> unhappyData = _context.feedbacks.Where(f => f.serviceName == "All NETWORK DATA" && f.rating < 6).Select(f => f.rating).ToList();

            //Counter per Service Rated

            List<Feedback> smsRated = _context.feedbacks.Where(f => f.serviceName == "SMS").ToList();
            List<Feedback> NightSufferRated = _context.feedbacks.Where(f => f.serviceName == "NIGHT SUFFER").ToList();
            List<Feedback> allMinutesRated = _context.feedbacks.Where(f => f.serviceName == "ALL NETWORK MINUTES").ToList();
            List<Feedback> allDATARated = _context.feedbacks.Where(f => f.serviceName == "All NETWORK DATA").ToList();

            //calcuated
            int alertss = _calculator.CountAlerts(alerts);
            int smsCSTscore  = _calculator.CalculatorCSAT(ratingsSMS);
            int dataCSTscore = _calculator.CalculatorCSAT(ratingsAllNetworkData);
            int nightSufferCSTscore = _calculator.CalculatorCSAT(ratingsSuffer);
            int allMinutesCSTscore = _calculator.CalculatorCSAT(ratingsAllNetworkMinutes);

            //unhappy to list

            int untotalHappySms = unhappyRatingsSMS.Count;
            int untotalHappyNight = unhappyNightSuffer.Count;
            int untotalHappyAll = unhappyAllNetwork.Count;
            int untotalHappy = unhappyData.Count;

            // to lsit

            int totalHappySms = happyRatingsSMS.Count;
            int totalHappyNight = happyNightSuffer.Count;
            int totalHappyAll = happyAllNetwork.Count;
            int totalHappy = happyData.Count;
            //count rated

            int totalRatedSms = smsRated.Count;
            int totalRateNitgh = NightSufferRated.Count;
            int totalMinutes  = allMinutesRated.Count;
            int totalDATAR = allDATARated.Count;

            var graph = new int[] {totalRatedSms,totalDATAR, totalRateNitgh, totalMinutes };

            var Happygrah = new int[] { totalHappySms, totalHappy, totalHappyAll,  totalHappyNight };

            var unHappygrah = new int[] { untotalHappySms, untotalHappy, untotalHappyAll,   untotalHappyNight };

            //Return to the view
            ViewBag.Provider = provider;
            ViewBag.smsScore = smsCSTscore;
            ViewBag.dataScore = dataCSTscore;
            ViewBag.nightSufferScore = nightSufferCSTscore;
            ViewBag.allMinutesScore = allMinutesCSTscore;
            ViewBag.NumberAlerts = alertss;


            //Return to view

            ViewBag.GraphData = JsonConvert.SerializeObject(graph);

            ViewBag.happyCustomer = JsonConvert.SerializeObject(Happygrah);

            ViewBag.unhappyCustomer = JsonConvert.SerializeObject(unHappygrah);



            return View(provider);
        }



        public IActionResult Analytics()
        {
            var username = HttpContext.Session.GetString("username");

            Models.ServiceProvider provider = _context.servicesProviders.FirstOrDefault(u => u.username == username);

            List<Customer> customerList = _context.customers.ToList();

            //Arrange by Group
            List<Customer> customers = _context.customers.ToList();

            ViewBag.AgeGroup = JsonConvert.SerializeObject(_calculator.grouobyAge(customers));

            ViewBag.customerList = customerList.Count;
            ViewBag.genderCounter = JsonConvert.SerializeObject(_calculator.countGender(customers));

            ViewBag.used =_calculator.usedService(customers);
            ViewBag.UnUsed = _calculator.UnusedService(customers);

            return View(provider);
        }


      
        public IActionResult Services()
        {
            var username = HttpContext.Session.GetString("username");

            Models.ServiceProvider provider = _context.servicesProviders.FirstOrDefault(u => u.username == username);


            var viewModel = new CombinedViewModel
            {

                ServiceProvider = provider
                
            };




            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Services(CombinedViewModel combinedViewModel)
        {


            var username = HttpContext.Session.GetString("username");
            var providerId = HttpContext.Session.GetString("providerId");

            Models.ServiceProvider provider = _context.servicesProviders.FirstOrDefault(u => u.username == username);

            combinedViewModel.Service.providerId = provider.providerId;


            if (combinedViewModel.Service != null)
            {

                _context.services.AddRange(new Service[]{ combinedViewModel.Service });
                _context.SaveChanges();
                
                return Ok();

         
            }
           
         



            var viewModel = new CombinedViewModel
            {

                ServiceProvider = provider,
                Service = combinedViewModel.Service
            };
          

            return View(viewModel);
        }


        public IActionResult Geoalerts()
        {
            var username = HttpContext.Session.GetString("username");

            Models.ServiceProvider provider = _context.servicesProviders.FirstOrDefault(u => u.username == username);

            List<GeoAlert> geoalerts = _context.geoalerts.ToList();


            ViewBag.proivnce = JsonConvert.SerializeObject(_calculator.countPerProvince(geoalerts));

            ViewBag.Geoalerts = geoalerts;  


            return View(provider);
        }

        public IActionResult Feedbacks()
        {
            var username = HttpContext.Session.GetString("username");

            Models.ServiceProvider provider = _context.servicesProviders.FirstOrDefault(u => u.username == username);

            List<Feedback> feedbacks = _context.feedbacks.ToList(); 

            ViewBag.Feedbacks = feedbacks;

            return View(provider);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
