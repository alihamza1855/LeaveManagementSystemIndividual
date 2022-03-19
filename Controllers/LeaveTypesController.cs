#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagementSystemIndividual.Data;
using LeaveManagementSystemIndividual.Models;
using AutoMapper;
using LeaveManagementSystemIndividual.ViewModels;
using LeaveManagementSystemIndividual.Contracts;

namespace LeaveManagementSystemIndividual.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;

        public LeaveTypesController(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            return View(mapper.Map<List<LeaveTypeVM>>(await leaveTypeRepository.GetAllAsync()));
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(mapper.Map<LeaveTypeVM>(leaveType));
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeVM leaveTypeVm)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVm);
                leaveType.DateCreated = DateTime.Now;
                leaveType.DateModified = DateTime.Now;
                await leaveTypeRepository.CreateAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVm);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var leaveType = mapper.Map<LeaveTypeVM>(await leaveTypeRepository.GetAsync(id));
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeVM leaveTypeVm)
        {
            if (id != leaveTypeVm.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVm);
                try
                {
                    leaveType.DateModified = DateTime.Now;
                    var leaveTypeVM = mapper.Map<LeaveTypeVM>(await leaveTypeRepository.UpdateAsync(leaveType));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LeaveTypeExists(leaveTypeVm.Id))
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
            return View(leaveTypeVm);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await leaveTypeRepository.GetAsync(id);
            await leaveTypeRepository.DeleteAsync(leaveType);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LeaveTypeExists(int id)
        {
            var result = await leaveTypeRepository.Exists(id);
            return result;
        }
    }
}
