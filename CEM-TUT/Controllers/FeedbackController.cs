using CEM_TUT.Data;
using CEM_TUT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;

namespace CEM_TUT.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly AppDbContext _context;

        public FeedbackController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string customerName,string service, string rating)
        {

            int rate = int .Parse(rating);

            var feedback = new Feedback
            {
                serviceName = service,
                rating = rate,
                customerName = customerName,
            };
            if (feedback != null) {

                _context.feedbacks.AddRange(feedback);
                _context.SaveChanges();
                return Ok();

            }


            return NoContent();
        }




        public IActionResult Geoalerts()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Geoalerts(string title, string description, string location, string serviceName)
        {

            var geoalert = new GeoAlert
            {
                title = title,
                description = description,
                loaction = location,
                serviceName = serviceName

            };

            if (geoalert != null)
            {

                _context.geoalerts.AddRange(geoalert);
                _context.SaveChanges();
                return Ok();

            }


            return NoContent();
        }

    }
}
