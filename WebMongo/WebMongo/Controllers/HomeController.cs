﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMongo.Models;

namespace WebMongo.Controllers
{
    public class HomeController : Controller
    {
        private readonly MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index(FilterViewModel filter)
        {
            var phones = await db.GetPhones(filter.MinPrice, filter.MaxPrice, filter.Name);
            var model = new IndexViewModel { Phones = phones, Filter = filter };
            return View(model);
        }

        public async Task<ActionResult> Show(FilterViewModel filter)
        {
            var phones = await db.GetPhones(filter.MinPrice, filter.MaxPrice, filter.Name);
            var model = new IndexViewModel { Phones = phones, Filter = filter };



            return View(model);
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Phone p)
        {
            if (ModelState.IsValid)
            {
                await db.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public async Task<IActionResult> Edit(string id)
        {
            Phone p = await db.GetPhone(id);
            if (p == null)
                return NotFound();
            return View(p);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Phone p)
        {
            if (ModelState.IsValid)
            {
                await db.Update(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> Delete(string id)
        {
            await db.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AttachImage(string id)
        {
            Phone p = await db.GetPhone(id);
            if (p == null)
                return NotFound();
            return View(p);
        }

    }
}
