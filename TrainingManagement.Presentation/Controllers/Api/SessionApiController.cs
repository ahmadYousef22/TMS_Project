using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;
using TrainingManagment.Domain.Models.Enums;
using TrainingManagment.Domain.ViewModels;
using TrainingManagment.Presentation.Controllers;
using TrainingManagment.Repository.Data;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Repository.Repositories;

namespace TrainingManagement.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SessionApiController : ControllerBase
    {
        private readonly ILogger<SessionApiController> _logger;
        private readonly IUnitOfWork _unitOfWork;
 


        public SessionApiController(  ILogger<SessionApiController> logger, IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        
        }


        [HttpPost("DeleteList")]
        
        public async Task<IActionResult> DeleteList([FromBody] List<int> deletedSessionIds)
        {
            if (deletedSessionIds == null)
            {
                return StatusCode(404, new { M = "Not Found" });
            }
            foreach (int a in deletedSessionIds)
            {
                if (a > 0)
                {
                    Session s = await _unitOfWork.Sessions.GetByIdAsync(a);
                    s.IsDeleted = true;
                    s.IsActive = false;
                    
                    await _unitOfWork.Complete();
                }

            }
            return StatusCode(200);

        }




    }
}
