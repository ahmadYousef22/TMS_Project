using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagement.Domain.ViewModels;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Repository.Repositories;

namespace TrainingManagement.Presentation.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Topics()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Years()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Types()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Trainers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddType()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddType(AddLookupViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Types));
            }
            var nameEnExist = await _unitOfWork.lookups.FindAsync(lookup => lookup.NameEn == viewModel.NameEn);

            if (nameEnExist != null)
            {
                ModelState.AddModelError("NameEn", $"{nameEnExist.NameEn} already exist");
                return View(viewModel);
            }

            var nameArExist = await _unitOfWork.lookups.FindAsync(lookup => viewModel.NameAr == lookup.NameAr);

            if (nameArExist != null)
            {
                ModelState.AddModelError("NameAr", $"{nameArExist.NameAr} already exist");
                return View(viewModel);
            }

            var type = new Lookup
            {
                CreatedBy = User.Identity.Name,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                LookupCategoryId = viewModel.LookupCategoryId,
                NameEn = viewModel.NameEn,
                NameAr = viewModel.NameAr
            };

            var lookup = await _unitOfWork.lookups.AddAsync(type);

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Types));
        }


        [HttpGet]
        public IActionResult AddTopic()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTopic(AddLookupViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Topics));
            }
            var nameEnExist = await _unitOfWork.lookups.FindAsync(lookup => lookup.NameEn == viewModel.NameEn);

            if (nameEnExist != null)
            {
                ModelState.AddModelError("NameEn", $"{nameEnExist.NameEn} already exist");
                return View(viewModel);
            }

            var nameArExist = await _unitOfWork.lookups.FindAsync(lookup => viewModel.NameAr == lookup.NameAr);

            if (nameArExist != null)
            {
                ModelState.AddModelError("NameAr", $"{nameArExist.NameAr} already exist");
                return View(viewModel);
            }

            var type = new Lookup
            {
                CreatedBy = User.Identity.Name,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                LookupCategoryId = viewModel.LookupCategoryId,
                NameEn = viewModel.NameEn,
                NameAr = viewModel.NameAr
            };

            var lookup = await _unitOfWork.lookups.AddAsync(type);

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Topics));
        }



        [HttpGet]
        public IActionResult AddTrainer()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTrainer(AddLookupViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Trainers));
            }
            var nameEnExist = await _unitOfWork.lookups.FindAsync(lookup => lookup.NameEn == viewModel.NameEn);

            if (nameEnExist != null)
            {
                ModelState.AddModelError("NameEn", $"{nameEnExist.NameEn} already exist");

                return View(viewModel);
            }

            var nameArExist = await _unitOfWork.lookups.FindAsync(lookup => viewModel.NameAr == lookup.NameAr);

            if (nameArExist != null)
            {
                ModelState.AddModelError("NameAr", $"{nameArExist.NameAr} already exist");

                return View(viewModel);
            }

            var type = new Lookup
            {
                CreatedBy = User.Identity.Name,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                LookupCategoryId = viewModel.LookupCategoryId,
                NameEn = viewModel.NameEn,
                NameAr = viewModel.NameAr
            };

            var lookup = await _unitOfWork.lookups.AddAsync(type);

            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Trainers));
        }



    }
}
