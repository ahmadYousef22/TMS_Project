using TrainingManagment.Domain.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Domain.Models;
using TrainingManagment.Domain.ViewModels;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using TrainingManagment.Domain.consts;
using TrainingManagment.Repository.Repositories;
using TrainingManagement.Domain.ViewModels;
using AspNetCore.Reporting;
using System.Text;
using TrainingManagment.Repository.Data;
using System.IO;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace TrainingManagment.Presentation.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class SessionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SessionsRepository _context;


        public SessionController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, SessionsRepository sessionsRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = sessionsRepository;
        }



        //--------------------------------------------------------------Action\/

        [HttpPost]
        public async Task<bool> ValidateTraineeName(string trainee, int trainerId, string year)
        {
            var existingSession = await _unitOfWork.Sessions.FindAsync(b => b.Year == year && b.TrainerName.Id == trainerId &&
                   b.TraineeName == trainee);

            if (existingSession != null)
            {
                return true;
            }
            return false;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                IEnumerable<Session> session = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive && !s.IsDeleted && s.Year == year, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus" });

                if (session == null)
                {
                    return NotFound();

                }

                SessionSearchViewModel sessionSearchViewModel = new SessionSearchViewModel();

                List<SessionViewModel> sessionsViewModel = new List<SessionViewModel>();
                foreach (Session session1 in session)
                {
                    sessionsViewModel.Add(MapSessionToViewModel(session1));
                }

                ViewBag.SessionsViewModel = sessionsViewModel;
                ViewBag.Types = _unitOfWork.lookups.GetAllTypes().ToList();
                ViewBag.Topics = _unitOfWork.lookups.GetAllTopics().ToList();
                ViewBag.Trainers = _unitOfWork.lookups.GetAllTrainer().ToList();
                ViewBag.Status = _unitOfWork.lookups.GetAllStatus().ToList();
                ViewBag.Results = _unitOfWork.lookups.GetAllResults().ToList();
                ViewBag.Year = _unitOfWork.lookups.GetAllYear();



                return View(sessionSearchViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving sessions.");
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid session ID");
            }

            Session sessionForDelete = await _unitOfWork.Sessions.GetByIdAsync(id);

            if (sessionForDelete == null)
            {
                return NotFound(); // Session not found
            }
            SessionViewModel viewModel = await MapSessionToViewModelWithAll(sessionForDelete);

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return StatusCode(404, "Invalid session ID");
            }
            if (id > 0)
            {
                Session sessionForDelete = await _unitOfWork.Sessions.GetByIdAsync(id);

                if (sessionForDelete == null)
                {
                    return NotFound(); // Session not found
                }

                sessionForDelete.IsActive = false;
                sessionForDelete.IsDeleted = true;
                _unitOfWork.Sessions.Update(sessionForDelete);
                await _unitOfWork.Complete();

            }
            return StatusCode(200);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Session session = await _unitOfWork.Sessions.FindAsync(s => s.SessionId == id, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" });

            if (session == null)
            {
                return NotFound();
            }

            SessionViewModel viewModel = MapSessionToViewModel(session);

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.Admin)]
        public IActionResult Create()
        {

            ViewBag.Types = _unitOfWork.lookups.GetAllTypes().ToList();
            ViewBag.Topics = _unitOfWork.lookups.GetAllTopics().ToList();
            ViewBag.Trainers = _unitOfWork.lookups.GetAllTrainer().ToList();
            ViewBag.Status = _unitOfWork.lookups.GetAllStatus().ToList();
            ViewBag.Years = _unitOfWork.lookups.GetAllYear().ToList();
            ViewBag.Results = _unitOfWork.lookups.GetAllResults().ToList();

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] List<SessionViewModel> newSessionData)
        {
            if (newSessionData == null)
            {
                return Json(new { message = "No data inserted." });
            }

            List<Session> AddedSessions = new List<Session>();
            try
            {
                foreach (SessionViewModel viewModel in newSessionData)
                {
                    AddedSessions.Add(MapViewModelToSession(viewModel));
                }

                foreach (var item in AddedSessions)
                {

                    var existingSession = await _unitOfWork.Sessions.FindAsync(b => b.Year == item.Year && b.TrainerName.Id == item.TrainerNameId &&
                        b.IsDeleted == false && b.TraineeName == item.TraineeName, new[] { "TrainerName" });


                    if (existingSession == null)
                    {
                        item.CreatedBy = this.User.Identity.Name;
                        item.TrainingStatusId = (int)LookupEnum.Status.Active;
                        await _unitOfWork.Sessions.AddAsync(item);
                    }
                    else
                    {
                        if (existingSession.TrainerName.Id == item.TrainerNameId)
                        {
                            return StatusCode(400, new { message = $"{item.TraineeName} already exists with {existingSession.TrainerName.NameEn} in this year!" });
                        }
                        else
                        {
                            item.CreatedBy = this.User.Identity.Name;
                            item.TrainingStatusId = (int)LookupEnum.Status.Active;
                            await _unitOfWork.Sessions.AddAsync(item);
                        }
                    }

                    await _unitOfWork.Complete();
                }

                return Json(new { message = "Session data inserted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }
        [Authorize(Roles = RoleName.Admin)]
        public async Task<IActionResult> UpdateSession(int Id)
        {
            var session = await _unitOfWork.Sessions.FindAsync(s => s.SessionId == Id, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus" });
            SessionViewModel viewModel = await MapSessionToViewModelWithAll(session);
            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSession(SessionViewModel UpdatedSession, IFormFile uploadedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Session afterUpdate = MapViewModelToSession(UpdatedSession);
                    afterUpdate.ModifyBy = this.User.Identity.Name;
                    afterUpdate.ModifyOn = DateTime.Now;

                    if (uploadedFile != null && uploadedFile.Length > 0)
                    {
                        if (IsExcelFile(uploadedFile))
                        {
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                            using (var dataStream = new MemoryStream())
                            {
                                await uploadedFile.CopyToAsync(dataStream);

                                using (var package = new ExcelPackage(dataStream))
                                {
                                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                                    if (worksheet != null)
                                    {
                                        if (worksheet.Dimension?.Rows > 0 && worksheet.Dimension?.Columns > 0)
                                        {
                                            var excelData = new List<Dictionary<string, string>>();

                                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                                            {
                                                bool isEmptyRow = true;
                                                var rowData = new Dictionary<string, string>();

                                                for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                                                {
                                                    string columnName = worksheet.Cells[1, col].Value?.ToString() ?? "";
                                                    string cellValue = worksheet.Cells[row, col].Value?.ToString() ?? "";


                                                    if (!string.IsNullOrWhiteSpace(cellValue))
                                                    {
                                                        isEmptyRow = false;
                                                    }

                                                    rowData[columnName] = cellValue;
                                                }

                                                if (!isEmptyRow)
                                                {
                                                    excelData.Add(rowData);
                                                }
                                            }

                                            afterUpdate.EvaluationFile = dataStream.ToArray();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            return BadRequest(new { message = "Please select a valid Excel file to upload." });
                        }
                    }
                    else
                    {

                        var existingSession = await _unitOfWork.Sessions.GetByIdAsync(afterUpdate.SessionId);
                        _unitOfWork.DetachEntity(existingSession);

                        afterUpdate.EvaluationFile = existingSession.EvaluationFile;
                    }

                    _unitOfWork.Sessions.Update(afterUpdate);
                    await _unitOfWork.Complete();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

            return View(UpdatedSession);
        }

        [HttpGet]
        public async Task<IActionResult> ViewEvaluationFile(int sessionId)
        {
            Session session = await _unitOfWork.Sessions.FindAsync(s => s.SessionId == sessionId);

            if (session != null && session.EvaluationFile != null)
            {
                using (var package = new ExcelPackage(new MemoryStream(session.EvaluationFile)))
                {

                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                    if (worksheet != null)
                    {

                        if (worksheet.Dimension?.Rows > 0 && worksheet.Dimension?.Columns > 0)
                        {

                            var excelData = new List<Dictionary<string, string>>();


                            for (int row = worksheet.Dimension.Start.Row + 1; row <= worksheet.Dimension.End.Row; row++)
                            {
                                var rowData = new Dictionary<string, string>();

                                for (int col = worksheet.Dimension.Start.Column; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    string columnName = worksheet.Cells[1, col].Value?.ToString() ?? "";
                                    string cellValue = worksheet.Cells[row, col].Value?.ToString() ?? "";


                                    rowData[columnName] = cellValue;
                                }

                                excelData.Add(rowData);
                            }
                            ViewBag.TraineeName = session.TraineeName;
                            ViewBag.SessionId = session.SessionId;

                            return View(excelData);
                        }
                    }
                }
            }


            return StatusCode(404);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadExcelFile(int sessionId)
        {

            Session session = await _unitOfWork.Sessions.FindAsync(s => s.SessionId == sessionId);

            if (session != null && session.EvaluationFile != null)
            {

                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


                return new FileStreamResult(new MemoryStream(session.EvaluationFile), contentType)
                {
                    FileDownloadName = $"{session.TraineeName}_EvaluationFile.xlsx" // Set the file name
                };
            }


            return StatusCode(404, "Please try again later or contact support if the issue persists.");
        }


        [HttpGet]
        [Authorize(Roles = RoleName.Admin)]
        public async Task<IActionResult> Update(string Year)
        {
            IEnumerable<Session> session = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive && !s.IsDeleted && s.Year == Year && s.TrainingStatusId == (int)LookupEnum.Status.Active, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus" });

            if (session == null)
            {
                return NotFound();

            }


            SessionViewModel sessionViewModel = new SessionViewModel();
            sessionViewModel.Year = Year;
            List<SessionViewModel> sessionsViewModel = new List<SessionViewModel>();

            foreach (Session session1 in session)
            {
                sessionsViewModel.Add(MapSessionToViewModel(session1));
            }

            ViewBag.SessionsViewModel = sessionsViewModel;
            ViewBag.Types = _unitOfWork.lookups.GetAllTypes().ToList();
            ViewBag.Topics = _unitOfWork.lookups.GetAllTopics().ToList();
            ViewBag.Trainers = _unitOfWork.lookups.GetAllTrainer().ToList();
            ViewBag.Status = _unitOfWork.lookups.GetAllStatus().ToList();
            ViewBag.Years = _unitOfWork.lookups.GetAllYear().ToList();
            ViewBag.Results = _unitOfWork.lookups.GetAllResults().ToList();

            return View(sessionViewModel);

        }


        [HttpPost]
        public async Task<IActionResult> Update([FromBody] List<SessionViewModel> newSessionData)
        {
            List<SessionViewModel> added = new List<SessionViewModel>();
            ///
            try
            {
                foreach (var item in newSessionData)
                {
                    if (item.SessionId > 0)
                    {

                        Session UpdatedSession = MapViewModelToSession(item);
                        UpdatedSession.ModifyBy = this.User.Identity.Name;
                        UpdatedSession.ModifyOn = DateTime.Now;

                        await _context.UpdateSession(UpdatedSession);
                        await _unitOfWork.Complete();
                    }
                    else if (item.SessionId < 0)
                    {
                        Session UpdatedSession = MapViewModelToSession(item);

                        UpdatedSession.CreatedBy = this.User.Identity.Name;
                        UpdatedSession.CreatedOn = DateTime.Now;
                        //UpdatedSession.Year = "2023";
                        UpdatedSession.SessionId = new int();
                        UpdatedSession.TrainingStatusId = (int)LookupEnum.Status.Active;
                        await _unitOfWork.Sessions.AddAsync(UpdatedSession);
                        await _unitOfWork.Complete();

                    }
                }



                return Json(new { success = true, message = "Session data inserted successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public async Task<List<SessionViewModel>> SearchSession(SessionSearchViewModel session)
        {

            var query = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive == true && s.IsDeleted == false, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" });

            if (session.Year != null)
            {
                query = query.Where(s => s.Year == session.Year);
            }
            if (session.Topic != null)
            {
                query = query.Where(s => s.TrainingTopic.NameEn == session.Topic);
            }
            if (session.Type != null)
            {
                query = query.Where(s => s.TrainingType.NameEn == session.Type);
            }

            if (session.TrainerName != null)
            {
                query = query.Where(s => s.TrainerName.NameEn == session.TrainerName);
            }

            if (session.TraineeName != null)
            {
                query = query.Where(s => s.TraineeName.ToLower().Contains(session.TraineeName.Trim().ToLower()) || s.TraineeName.ToUpper().Contains(session.TraineeName.Trim().ToUpper()));

            }

            if (session.StartDate != null)
            {
                query = query.Where(s => s.StartDate.Date == session.StartDate);
            }


            if (session.EndDate != null)
            {
                query = query.Where(s => s.ExpectedEndDate.Date == session.EndDate);
            }

            if (session.Status != null)
            {
                query = query.Where(s => s.TrainingStatus.NameEn == session.Status);
            }


            if (session.Result != null)
            {
                query = query.Where(s => s.TrainingResult != null && s.TrainingResult.NameEn == session.Result);
            }

            var filteredSessions = query.ToList();

            var sessionViewModels = filteredSessions.Select(session => new SessionViewModel
            {
                Year = session.Year,
                TraineeName = session.TraineeName,
                TrainerName = session.TrainerName,
                TrainingType = session.TrainingType,
                StartDate = session.StartDate,
                ExpectedEndDate = session.ExpectedEndDate,
                TrainingStatus = session.TrainingStatus,
                TrainingTopic = session.TrainingTopic,
                SessionId = session.SessionId,
                TrainingResult = session.TrainingResult,

            }).ToList();
            return sessionViewModels;
        }

        [HttpGet]
        public async Task<IActionResult> Search(SessionSearchViewModel session)
        {


            //var query = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive == true && s.IsDeleted == false, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" });

            // if (session.Year != null)
            //{
            //    query = query.Where(s => s.Year == session.Year);
            //}
            //if (session.Topic != null)
            //{
            //    query = query.Where(s => s.TrainingTopic.NameEn == session.Topic);
            //}
            //if (session.Type != null)
            //{
            //    query = query.Where(s => s.TrainingType.NameEn == session.Type);
            //}

            //if (session.TrainerName != null)
            //{
            //    query = query.Where(s => s.TrainerName.NameEn == session.TrainerName);
            //}

            //if (session.TraineeName != null)
            //{
            //    query = query.Where(s => s.TraineeName.ToLower().Contains(session.TraineeName.Trim().ToLower()) || s.TraineeName.ToUpper().Contains(session.TraineeName.Trim().ToUpper()));

            //}

            //if (session.StartDate != null)
            //{
            //    query = query.Where(s => s.StartDate.Date ==session.StartDate); 
            //}


            //if (session.EndDate != null)
            //{
            //    query = query.Where(s => s.ExpectedEndDate.Date == session.EndDate);
            //}

            //if (session.Status != null)
            //{
            //    query = query.Where(s => s.TrainingStatus.NameEn == session.Status);
            //}


            //if (session.Result != null)
            //{
            //    query = query.Where(s => s.TrainingResult != null && s.TrainingResult.NameEn == session.Result);
            //}

            // var filteredSessions = query.ToList();

            var sessionViewModels = await SearchSession(session);
            // return Json(sessionViewModels);


            return StatusCode(200, sessionViewModels);


        }

        [HttpGet]
        public async Task<IActionResult> GenerateReport()
        {

            DataTable reportDataTable = new DataTable();


            reportDataTable.Columns.Add("StartDate", typeof(string));
            reportDataTable.Columns.Add("ExpectedEndDate", typeof(string));
            reportDataTable.Columns.Add("ActualEndDate", typeof(string));
            reportDataTable.Columns.Add("Year", typeof(string));
            reportDataTable.Columns.Add("TraineeName", typeof(string));
            reportDataTable.Columns.Add("TrainingResult", typeof(string));
            reportDataTable.Columns.Add("TrainingTopic", typeof(string));
            reportDataTable.Columns.Add("TrainingType", typeof(string));
            reportDataTable.Columns.Add("TrainingStatus", typeof(string));
            reportDataTable.Columns.Add("TrainerName", typeof(string));
            reportDataTable.Columns.Add("FinalPresentationDate", typeof(string));
            reportDataTable.Columns.Add("EvaluationScore", typeof(double));
            reportDataTable.Columns.Add("Comments", typeof(string));


            IEnumerable<Session> sessions = await _unitOfWork.Sessions.FindAllAsync(
                s => s.IsActive == true && s.IsDeleted == false,
                new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" }
            );


            foreach (Session session in sessions)
            {
                reportDataTable.Rows.Add(
                    session.StartDate.Date.ToString("yyyy-MM-dd"),
                    session.ExpectedEndDate.Date.ToString("yyyy-MM-dd"),
                    session.ActualEndDate?.ToString("yyyy-MM-dd"),
                    session.Year,
                    session.TraineeName,
                    session.TrainingResult?.NameEn,
                    session.TrainingTopic.NameEn,
                    session.TrainingType.NameEn,
                    session.TrainingStatus.NameEn,
                    session.TrainerName.NameEn,
                    session.FinalPresentationDate?.ToString("yyyy-MM-dd"),
                    session.EvaluationScore,
                    session.Comment
                );
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sessions");

                worksheet.Cells["A1"].LoadFromDataTable(reportDataTable, true);

                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());
                stream.Position = 0;

                HttpContext.Response.Headers.Add("content-disposition", "attachment;filename=SessionsReport.xlsx");
                HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GenerateReportwithSearch(SessionSearchViewModel sessionSearch)
        {
            var query = await SearchSession(sessionSearch);


            List<SessionViewModel> sessions = query.ToList();
            DataTable reportDataTable = new DataTable();


            reportDataTable.Columns.Add("StartDate", typeof(string));
            reportDataTable.Columns.Add("ExpectedEndDate", typeof(string));
            reportDataTable.Columns.Add("ActualEndDate", typeof(string));
            reportDataTable.Columns.Add("Year", typeof(string));
            reportDataTable.Columns.Add("TraineeName", typeof(string));
            reportDataTable.Columns.Add("TrainingResult", typeof(string));
            reportDataTable.Columns.Add("TrainingTopic", typeof(string));
            reportDataTable.Columns.Add("TrainingType", typeof(string));
            reportDataTable.Columns.Add("TrainingStatus", typeof(string));
            reportDataTable.Columns.Add("TrainerName", typeof(string));
            reportDataTable.Columns.Add("FinalPresentationDate", typeof(string));
            reportDataTable.Columns.Add("EvaluationScore", typeof(double));
            reportDataTable.Columns.Add("Comments", typeof(string));


            foreach (SessionViewModel session in sessions)
            {
                reportDataTable.Rows.Add(
                    session.StartDate.Date.ToString("yyyy-MM-dd"),
                    session.ExpectedEndDate.Date.ToString("yyyy-MM-dd"),
                    session.ActualEndDate?.ToString("yyyy-MM-dd"),
                    session.Year,
                    session.TraineeName,
                    session.TrainingResult?.NameEn,
                    session.TrainingTopic.NameEn,
                    session.TrainingType.NameEn,
                    session.TrainingStatus.NameEn,
                    session.TrainerName.NameEn,
                    session.FinalPresentationDate?.ToString("yyyy-MM-dd"),
                    session.EvaluationScore,
                    session.Comment
                );
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sessions");

                worksheet.Cells["A1"].LoadFromDataTable(reportDataTable, true);

                worksheet.Cells.AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());
                stream.Position = 0;

                HttpContext.Response.Headers.Add("content-disposition", "attachment;filename=SessionsReport.xlsx");
                HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            }

        }




        public async Task<IActionResult> Report()
        {
            DataTable ReportDataTable = new DataTable();

            ReportDataTable.Columns.Add("SessionId", typeof(int));
            ReportDataTable.Columns.Add("StartDate", typeof(string));
            ReportDataTable.Columns.Add("ExpectedEndDate", typeof(string));
            ReportDataTable.Columns.Add("AcctualEndDate", typeof(string));
            ReportDataTable.Columns.Add("Year", typeof(string));
            ReportDataTable.Columns.Add("TraineeName", typeof(string));
            ReportDataTable.Columns.Add("TrainingResult", typeof(string));
            ReportDataTable.Columns.Add("TrainingTopic", typeof(string));
            ReportDataTable.Columns.Add("TrainingType", typeof(string));
            ReportDataTable.Columns.Add("TrainingStatus", typeof(string));
            ReportDataTable.Columns.Add("TrainerName", typeof(string));
            ReportDataTable.Columns.Add("FinalPresintationDate", typeof(string));
            ReportDataTable.Columns.Add("EvaluationScore", typeof(double));
            ReportDataTable.Columns.Add("Comments", typeof(string));

            IEnumerable<Session> sessions = await _unitOfWork.Sessions.FindAllAsync(s => (s.IsActive == true && s.IsDeleted == false && s.Year == DateTime.Now.Year.ToString()), new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus" });

            foreach (Session session in sessions)
            {
                ReportDataTable.Rows.Add(session.SessionId, session.StartDate.Date.ToString(), session.ExpectedEndDate.Date.ToString(), session.ActualEndDate.ToString(),
                    session.Year, session.TraineeName, session.TrainingResult?.NameEn, session.TrainingTopic.NameEn,
                    session.TrainingType.NameEn, session.TrainingStatus.NameEn, session.TrainerName.NameEn,
                    session.FinalPresentationDate.ToString(), session.EvaluationScore, session.Comment);
            }

            var path = "..\\TrainingManagement.Report\\Report\\Report.rdlc";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            LocalReport lr = new LocalReport(path);
            lr.AddDataSource("SessionDS", ReportDataTable);

            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var result = lr.Execute(RenderType.Excel, 1, parameters, "");

            return new FileContentResult(result.MainStream, "application/vnd.ms-excel");

            //return new FileContentResult(result.MainStream, "application/pdf");
            //{
            //    FileDownloadName = "Sessions Report"
            //};
        }


        private bool IsExcelFile(IFormFile file)
        {
            var allowedExtensions = new[] { ".xlsx", ".xls" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return false;
            }

            var maxFileSizeBytes = 10 * 1024 * 1024; // 10 MB  

            if (file.Length > maxFileSizeBytes)
            {
                return false;
            }

            return true;
        }
        public SessionViewModel MapSessionToViewModel(Session session)
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
                TrainerName = session.TrainerName,
                TrainingStatus = session.TrainingStatus,
                TrainingResult = session.TrainingResult,
                TrainingTopic = session.TrainingTopic,
                TrainingType = session.TrainingType,
                ResultsList = _unitOfWork.lookups.GetAllResults(),
                TopicsList = _unitOfWork.lookups.GetAllTopics(),
                TypesList = _unitOfWork.lookups.GetAllTypes(),
                TrainersList = _unitOfWork.lookups.GetAllTrainer(),
                StatusList = _unitOfWork.lookups.GetAllStatus(),
                YearsList = _unitOfWork.lookups.GetAllYear(),
                Isdeleted = session.IsDeleted,
                EvaluationFile = session.EvaluationFile
            };
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
                SessionsList = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive == true && s.IsDeleted == false, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" }),
                EvaluationFile = session.EvaluationFile


            };
        }

        public Session MapViewModelToSession(SessionViewModel viewModel)
        {
            return new Session
            {
                SessionId = viewModel.SessionId,
                StartDate = viewModel.StartDate,
                ExpectedEndDate = viewModel.ExpectedEndDate,
                ActualEndDate = viewModel.ActualEndDate,
                Year = viewModel.Year,
                TraineeName = viewModel.TraineeName,
                FinalPresentationDate = viewModel.FinalPresentationDate,
                EvaluationScore = viewModel.EvaluationScore,
                Comment = viewModel.Comment,
                TrainingResultId = viewModel.TrainingResultId,
                TrainingTopicId = viewModel.TrainingTopicId,
                TrainingTypeId = viewModel.TrainingTypeId,
                TrainingStatusId = viewModel.TrainingStatusId,
                TrainerNameId = viewModel.TrainerNameId,
                TrainingStatus = viewModel.TrainingStatus,
                TrainingResult = viewModel.TrainingResult,
                TrainingTopic = viewModel.TrainingTopic,
                TrainingType = viewModel.TrainingType,
                EvaluationFile = viewModel.EvaluationFile

            };
        }

    }
}
