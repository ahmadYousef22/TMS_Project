using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingManagement.Presentation.Controllers.Api;
using TrainingManagment.Domain.Models;
using TrainingManagment.Domain.Models.Enums;
using TrainingManagment.Domain.ViewModels;
using TrainingManagment.Repository.Data;
using TrainingManagment.Repository.Interfaces;
using static TrainingManagment.Domain.Models.Enums.LookupEnum;

namespace TrainingManagment.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly  ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _context = applicationDbContext;
        }
 
        public IActionResult Index()
        {

            _unitOfWork.lookups.CheckYear(User.Identity.Name);

            ViewBag.Years = _unitOfWork.lookups.GetAllYear();
            ViewBag.Status = _unitOfWork.lookups.GetAllStatus();
            string currentYear = DateTime.Now.Year.ToString();

            ViewBag.AllTrainees = _unitOfWork.Sessions.NumberOfTrainees();
            ViewBag.ActiveTrainees = _unitOfWork.Sessions.NumberOfTrainees("Active");
            ViewBag.FinishedTrainees = _unitOfWork.Sessions.NumberOfTrainees( "Finished");
            ViewBag.PendingTrainees = _unitOfWork.Sessions.NumberOfTrainees( "Pending");

            return View();
            }


        [HttpGet]
        public IActionResult Index2(string currentYear, string status)
        {
            if (currentYear == null)
            {
                currentYear = DateTime.Now.Year.ToString();
            }

            //get data by default 
            var sessionsQuery = _context.Session
                .Where(s => s.Year == currentYear && s.IsActive);

             if (!string.IsNullOrEmpty(status))
            {
                sessionsQuery = sessionsQuery.Where(s => s.TrainingStatus.NameEn == status);
            }

            var topics = sessionsQuery
                .GroupBy(s => s.TrainingTopic.NameEn)
                .Select(g => new
                {
                    Topic = g.Key,
                    TraineeCount = g.Count()
                })
                .ToList();

            var types = _context.Session.Where(s =>s.IsActive)
                .GroupBy(s => s.TrainingType.NameEn)
                .Select(g => new
                {
                    Type = g.Key,
                    TraineeCount = g.Count()
                })
                .ToList();

            var SessionResult = sessionsQuery
                .Where(s => s.TrainingResult.NameEn != null)
                .GroupBy(s => s.TrainingResult.NameEn)
                .Select(g => new
                {
                    Result = g.Key,
                    TraineeCount = g.Count()
                })
                .ToList();

            ViewBag.Topics = topics.Select(s => s.Topic).ToList();

            

          
 
                var acceptedCount = _unitOfWork.Sessions.NumberOfAcceptedTrainees(currentYear,status);
                var rejectedCount = _unitOfWork.Sessions.NumberOfRejectedTrainees(currentYear,status);

             
            var result = new
            {
                Topics = topics,
                Types = types,
                AcceptedCount = acceptedCount,
                RejectedCount = rejectedCount,
                Tresult = SessionResult
            };

            return Json(result);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<SessionViewModel> MapSessionToViewModelWithAll(Session session)
        {
            return new SessionViewModel
            {
                SessionId = session.SessionId,
                StartDate = session.StartDate,
                ExpectedEndDate = session.ExpectedEndDate,
                ActualEndDate = session.ActualEndDate,
                Year = session.Year,
                TraineeName = session.TraineeName,
                FinalPresentationDate = session.FinalPresentationDate,
                EvaluationScore = session.EvaluationScore,
                Comment = session.Comment,
                TrainingResultId = session.TrainingResultId,
                TrainingTopicId = session.TrainingTopicId,
                TrainingTypeId = session.TrainingTypeId,
                TrainingStatusId = session.TrainingStatusId,
                TrainerNameId = session.TrainerNameId,
                ResultsList = _unitOfWork.lookups.GetAllResults(),
                TopicsList = _unitOfWork.lookups.GetAllTopics(),
                TypesList = _unitOfWork.lookups.GetAllTypes(),
                TrainersList = _unitOfWork.lookups.GetAllTrainer(),
                StatusList = _unitOfWork.lookups.GetAllStatus(),
                YearsList = _unitOfWork.lookups.GetAllYear(),
                TrainerName = session.TrainerName,
                TrainingStatus = session.TrainingStatus,
                TrainingResult = session.TrainingResult,
                TrainingTopic = session.TrainingTopic,
                TrainingType = session.TrainingType,
                SessionsList = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive == true && s.IsDeleted == false, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" })


            };
        }

    }
}
