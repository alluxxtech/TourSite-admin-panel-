using AdminWebSite.DAL;
using AdminWebSite.DAL.Entities;
using AdminWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebSite.Controllers
{
    public class CountryController : Controller
    {
        EFContext _context;
        public CountryController()
        {
            _context = new EFContext();
            ViewBag.MenuCountry = true;

        }
        // GET: Country
        public ActionResult Index()
        {
            List<CountryViewModel> model;
            model = _context
                .Countries
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Priority = c.Priority,
                    DateCreate = c.DateCreate
                })
                .OrderBy(c => c.Priority)
                .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CountryCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Country country = new Country
                {
                    DateCreate = DateTime.Now,
                    Name = model.Name,
                    Priority = model.Priority
                };
                _context.Countries.Add(country);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Дружок не тупи!!!");
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country != null)
            {
                var model = new CountryEditViewModel
                {
                    Id = country.Id,
                    Name = country.Name,
                    Priority = country.Priority
                };
                return View(model);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Edit(CountryEditViewModel model)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == model.Id);
            if( country != null)
            {
                country.Name = model.Name;
                country.Priority = model.Priority;

                _context.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);

            var model = new CountryDetailsModel
            {
                Id = country.Id,
                Name = country.Name,
                DateCreate = country.DateCreate,
                Priority = country.Priority
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if ( country != null)
            {
                _context.Countries.Remove(country);
                _context.SaveChanges();
               
            }
            
            return RedirectToAction("Index");
        }
    }
}