// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/08/10
// See License.txt for more information
// ==================================

using Microsoft.AspNetCore.Mvc;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;

namespace AutoLot.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MakesController : Controller
    {
        private readonly IMakeRepo _repo;

        public MakesController(IMakeRepo repo)
        {
            _repo = repo;
        }

        // GET: Admin/Makes
        [Route("/Admin")]
        [Route("/Admin/[controller]")]
        [Route("/Admin/[controller]/[action]")]
        public IActionResult Index()
        {
            return View(_repo.GetAll());
        }

        // GET: Admin/Makes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Makes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id,TimeStamp")] Make make)
        {
            if (!ModelState.IsValid) return View(make);
            _repo.Add(make);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Makes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // GET: Admin/Makes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Admin/Makes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id,TimeStamp")] Make make)
        {
            if (id != make.Id)
            {
                return NotFound();
            }

            _repo.Update(make);
            return RedirectToAction(nameof(Index));
        }
        // GET: Admin/Makes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Admin/Makes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Make make)
        {
            if (id != make.Id)
            {
                return BadRequest();
            }
            _repo.Delete(make);
            return RedirectToAction(nameof(Index));
        }
    }
}