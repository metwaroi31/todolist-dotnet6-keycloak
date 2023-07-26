﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using todolist_dotnet6_keycloak.Models;

namespace todolist_dotnet6_keycloak
{
    public class UserModelsController : Controller
    {
        private readonly TodolistContext _context;

        public UserModelsController(TodolistContext context)
        {
            _context = context;
        }

        // GET: UserModels
        public async Task<IActionResult> Index()
        {
              return _context.UserModels != null ? 
                          View(await _context.UserModels.ToListAsync()) :
                          Problem("Entity set 'TodolistContext.UserModels'  is null.");
        }

        // GET: UserModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModels
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: UserModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,CreatedAt")] UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: UserModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: UserModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Password,CreatedAt")] UserModel userModel)
        {
            if (id != userModel.Username)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.Username))
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
            return View(userModel);
        }

        // GET: UserModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserModels == null)
            {
                return NotFound();
            }

            var userModel = await _context.UserModels
                .FirstOrDefaultAsync(m => m.Username == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: UserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserModels == null)
            {
                return Problem("Entity set 'TodolistContext.UserModels'  is null.");
            }
            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel != null)
            {
                _context.UserModels.Remove(userModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModelExists(string id)
        {
          return (_context.UserModels?.Any(e => e.Username == id)).GetValueOrDefault();
        }
    }
}
