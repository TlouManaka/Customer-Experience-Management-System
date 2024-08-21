using CEM_TUT.Data;
using Microsoft.AspNetCore.Mvc;

namespace CEM_TUT.Controllers
{
    public class AccountController : Controller
    {

        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.ServiceProvider provider)
        {

            if (provider != null)
            {

                _context.servicesProviders.AddRange(new Models.ServiceProvider[] { provider });
                _context.SaveChanges();
                return Ok();

            }

            return View();
        }
    }
}
