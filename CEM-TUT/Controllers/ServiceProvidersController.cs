using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CEM_TUT.Data;
using CEM_TUT.Models;

namespace CEM_TUT.Controllers
{
    public class ServiceProvidersController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceProvidersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ServiceProviders
        public async Task<IActionResult> Index()
        {
            return View(await _context.servicesProviders.ToListAsync());
        }

        // GET: ServiceProviders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.servicesProviders
                .FirstOrDefaultAsync(m => m.providerId == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // GET: ServiceProviders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceProviders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("providerId,providerName,username,password")] Models.ServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                _context.servicesProviders.Add(serviceProvider);
                await _context.SaveChangesAsync();
                return Redirect("did not save");
            }
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.servicesProviders.FindAsync(id);
            if (serviceProvider == null)
            {
                return NotFound();
            }
            return View(serviceProvider);
        }

        // POST: ServiceProviders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("providerId,providerName,username,password")] Models.ServiceProvider serviceProvider)
        {
            if (id != serviceProvider.providerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceProvider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceProviderExists(serviceProvider.providerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serviceProvider);
        }

        // GET: ServiceProviders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceProvider = await _context.servicesProviders
                .FirstOrDefaultAsync(m => m.providerId == id);
            if (serviceProvider == null)
            {
                return NotFound();
            }

            return View(serviceProvider);
        }

        // POST: ServiceProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceProvider = await _context.servicesProviders.FindAsync(id);
            if (serviceProvider != null)
            {
                _context.servicesProviders.Remove(serviceProvider);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceProviderExists(int id)
        {
            return _context.servicesProviders.Any(e => e.providerId == id);
        }
    }
}
