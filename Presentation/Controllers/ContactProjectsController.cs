﻿using AutoMapper;
using CredensPet.Infrastructure;
using CredensPet.Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Profiles;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class ContactProjectsController : Controller
    {
        private readonly IService<ContactProjectDTO> _serviceContactProject;
        private readonly IService<ProjectDTO> _serviceProject;
        private readonly IMapper _mapperToView;
        private readonly IMapper _mapperToDTO;

        public ContactProjectsController(IService<ContactProjectDTO> serviceContactProject, IService<ProjectDTO> serviceProject)
        {
            _serviceContactProject = serviceContactProject;
            _serviceProject = serviceProject; 
            _mapperToView = GenericMapperConfiguration<ContactProjectDTO, ContactProjectViewModel>.MapTo();
            _mapperToDTO = GenericMapperConfiguration<ContactProjectViewModel, ContactProjectDTO>.MapTo();
        }

        // GET: ContactProjects
        public IActionResult Index()
        {
            var item = _mapperToView.ProjectTo<ContactProjectViewModel>(_serviceContactProject.FindAll().AsNoTracking());
              return item != null ? 
                          View(item) :
                          Problem("Entity set 'CredensTestContext.Contacts'  is null.");
        }

        // GET: ContactProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(await _serviceContactProject.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            return View(item);
        }

        // GET: ContactProjects/Create
        public IActionResult Create(int id)
        {
            //ViewBag.ProjectId = new SelectList( _serviceProject.FindAll().Where(x => x.ProjectId == id));
            var item = _serviceProject.FindAll().FirstOrDefault(x => x.ProjectId == id);
            //if (item.Cu != null)
            //{
            //    throw new ArgumentNullException(nameof(entity.ProjectId));
            //}

            return View();
        }

        // POST: ContactProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "ProjectId, ContactProjectId, Country," +
                        " City, ResidentialComplex, TypeStreet, Street, BuildingNumber, " +
                        "Litera, BuildingPart, Apt, Floor")] ContactProjectViewModel contactProjectViewModel)
        { 
            if (ModelState.IsValid)
            {
                await _serviceContactProject.AddAsync(_mapperToDTO.Map<ContactProjectDTO>(contactProjectViewModel));
                await _serviceContactProject.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Projects");
        }

        // GET: ContactProjects/Update/5
        public async Task<IActionResult> Update(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(await _serviceContactProject.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: ContactProjects/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, [Bind("ContactProjectId, ProjectId, Country, City,ResidentialComplex,TypeStreet,Street,BuildingNumber,Lit,BuildingPart,Apt,Floor")] ContactProjectViewModel contactProjectViewModel)
        {
            if (id != contactProjectViewModel.ContactProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    await _serviceContactProject.UpdateAsync(_mapperToDTO.Map<ContactProjectDTO>(contactProjectViewModel));
                    await _serviceContactProject.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: ContactProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = _mapperToView.Map<ContactProjectViewModel>(await _serviceContactProject.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (id == null || _serviceContactProject == null || item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: ContactProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_serviceContactProject == null)
            {
                return Problem("Entity set 'CredensTestContext.Contacts'  is null.");
            }
            var item = _mapperToDTO.Map<ContactProjectDTO>(await _serviceContactProject.FindAll()
                .FirstOrDefaultAsync(x => x.ContactProjectId == id));
            if (item != null)
            {
                await _serviceContactProject.DeleteAsync(item);
            }

            await _serviceContactProject.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}