using CEM_TUT.Data;
using CEM_TUT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;

namespace CEM_TUT.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext   _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string cellNumber, string email, string location,string serviceName,string age,string gender)
        {

            var customer = new Customer
            {
                Name = name,
                cellNumber = cellNumber,
                email = email,
                location = location,
                serviceName = serviceName,
                age = age,
                gender = gender

            };
            if (customer != null)
            {

                _context.customers.AddRange(customer);
                _context.SaveChanges();
                return Ok();

            }

            return View();
        }
    }
}
