﻿using LeaveManagementSystem.Web.Models.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveRequests;
using LeaveManagementSystem.Web.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LeaveManagementSystem.Web.Controllers;

[Authorize]
public class LeaveRequestsController(ILeaveTypesService _leaveTypesService, ILeaveRequestsService _leaveRequestsService) : Controller
{
    // Employee View Requests
    public async Task<IActionResult> Index()
    {
        var model = await _leaveRequestsService.GetEmployeeLeaveRequests();

        return View(model);
    }

    // Employee Create Requests
    public async Task<IActionResult> Create(int? leaveTypeId)
    {
        var leaveTypes = await _leaveTypesService.GetAll();
        var leaveTypesList = new SelectList(leaveTypes, "Id", "Name", leaveTypeId);
        var model = new LeaveRequestCreateVM
        {
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),

            LeaveTypes = leaveTypesList,
        };
        return View(model);
    }

    // Employee create Request
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveRequestCreateVM model)
    {
        // validate that the days don't exceed the allocation
        if(await _leaveRequestsService.RequestDatesExceedAllocation(model))
        {
            ModelState.AddModelError(string.Empty, "You have exceeded your allocation");
            ModelState.AddModelError(nameof(model.EndDate), "The number of days requested is invalid");
        }
        if (ModelState.IsValid)
        {
            await _leaveRequestsService.CreateLeaveRequest(model);
            return RedirectToAction(nameof(Index));
        }

        var leaveTypes = await _leaveTypesService.GetAll();
        model.LeaveTypes = new SelectList(leaveTypes, "Id", "Name");

        return View(model);
    }

    // Employee Cancel Requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Cancel(int id)
    {
        await _leaveRequestsService.CancelLeaveRequest(id);
        return RedirectToAction(nameof(Index));
    }

    // Admin/Supe review Requests
    [Authorize(Policy = "AdminSupervisorOnly")]
    public async Task<IActionResult> ListRequests()
    {
        var model = await _leaveRequestsService.AdminGetAllLeaveRequests();
        return View(model);
    }

    // Admin/Supe review Requests
    public async Task<IActionResult> Review(int id)
    {
        var model = await _leaveRequestsService.GetLeaveRequestForReview(id);
        return View(model);
    }

    // Admin/Supe review Requests
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Review(int id, bool approved)
    {
        await _leaveRequestsService.ReviewLeaveRequest(id, approved);
        return RedirectToAction(nameof(ListRequests));
    }
}
