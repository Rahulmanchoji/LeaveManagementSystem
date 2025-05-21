using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.Leave_Types;
using AutoMapper;
using LeaveManagementSystem.Web.Services;

namespace LeaveManagementSystem.Web.Controllers
{
    public class LeavetypesController(ILeavetypesService _leavetypesService) : Controller
    { 
        private const string NameExistsValidationMessage = "This leave type already exists in the database";

        // GET: Leavetypes
        public async Task<IActionResult> Index()
        {
           var viewData = await _leavetypesService.GetAll();
            //var viewData = data.Select(q => new IndexVM
            //{
            //    Id = q.Id,
            //    Name = q.Name,
            //    NumberOfDays = q.NumberOfDays,
            //});
            return View(viewData);
        }

        // GET: Leavetypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leavetype = await _leavetypesService.Get<LeavetypeReadOnlyVM>(id.Value);
            if (leavetype == null)
            {
                return NotFound();
            }
            return View(leavetype);
        }

        // GET: Leavetypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leavetypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeavetypeCreateVM leavetypeCreate)
        {
            //Adding Custom validation and model state error
            if (await _leavetypesService.CheckIfLeavetypeNameExists(leavetypeCreate.Name))
            {
                ModelState.AddModelError(nameof(leavetypeCreate.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                await _leavetypesService.Create(leavetypeCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(leavetypeCreate);
        }

     
        // GET: Leavetypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavetype = await _leavetypesService.Get<LeavetypeEditVM>(id.Value);
            if (leavetype == null)
            {
                return NotFound();
            }
            return View(leavetype);
        }

        // POST: Leavetypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeavetypeEditVM leavetypeEdit)
        {
            if (id != leavetypeEdit.Id)
            {
                return NotFound();
            }

            //Adding Custom validation and model state error
            if (await _leavetypesService.CheckIfLeavetypeNameExistsForEdit(leavetypeEdit))
            {
                ModelState.AddModelError(nameof(leavetypeEdit.Name), NameExistsValidationMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _leavetypesService.Edit(leavetypeEdit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_leavetypesService.LeavetypeExists(leavetypeEdit.Id))
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
            return View(leavetypeEdit);
        }

       
        // GET: Leavetypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leavetype = await _leavetypesService.Get<LeavetypeReadOnlyVM>(id.Value);
            if (leavetype == null)
            {
                return NotFound();
            }
            return View(leavetype);
        }

        // POST: Leavetypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _leavetypesService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
