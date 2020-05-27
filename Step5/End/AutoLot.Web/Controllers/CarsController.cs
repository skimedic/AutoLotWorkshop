using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;

namespace AutoLot.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = 
                _context.Cars.Include(c => c.MakeNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet("{makeId}/{makeName}")]
        public IActionResult ByMake([FromServices]ICarRepo carRepo, int makeId, string makeName)
        {
            ViewBag.MakeName = makeName;
            return View(carRepo.GetAllBy(makeId));
        }

        // GET: Cars/Details/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.MakeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        internal SelectList GetMakes()
            => new SelectList(_context.Makes, nameof(Make.Id), nameof(Make.Name));
        // GET: Cars/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["MakeId"] = GetMakes();
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakeId,Color,PetName,Id,TimeStamp")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = GetMakes();
            return View(car);
        }

        // GET: Cars/Edit/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["MakeId"] = GetMakes();
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakeId,Color,PetName,Id,TimeStamp")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["MakeId"] = GetMakes();
            return View(car);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id)
        {
            var vm = new Car();
            if (await TryUpdateModelAsync(vm,"",
                c=>c.Id,c=>c.MakeId, c=>c.TimeStamp))
            {
                //Color doesn't get updated because it's not in the list
                //c=>c.Color, 
                //Petname from the forms is ignored but hard coded later
                //c=>c.PetName, 
            }
            var valid0 = ModelState.IsValid;
            ModelState.Clear();
            vm.PetName = "Model T";
            vm.Color = "Black";
            var valid1 = TryValidateModel(vm);
            var valid2 = ModelState.IsValid;
            ViewData["MakeId"] = GetMakes();
            return View("Edit",vm);
        }

        // GET: Cars/Delete/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.MakeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
