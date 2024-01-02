using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingManagment.Repository.Interfaces;
using static TrainingManagment.Domain.Models.Enums.LookupEnum;

namespace TrainingManagement.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChartsController : ControllerBase
    {

         private readonly IUnitOfWork _unitOfWork;

        public ChartsController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;

        }



        [HttpGet("GetNumberOfTrainees")]
        public IActionResult GetNumberOfTrainees(string year)
        {
            var NumberOfTrainees = _unitOfWork.Sessions.NumberOfTrainees(year);

            return Ok(NumberOfTrainees);
        }

        [HttpGet("GetNumberOfAcceptedTrainees")]
        public IActionResult GetNumberOfAcceptedTrainees(string year)
        {
            var NumberOfAcceptedTrainees = _unitOfWork.Sessions.NumberOfAcceptedTrainees(year);

            return Ok(NumberOfAcceptedTrainees);
        }

        [HttpGet("GetNumberOfRejectedTrainees")]
        public IActionResult GetNumberOfRejectedTrainees(string year)
        {
            var GetNumberOfRejectedTrainees = _unitOfWork.Sessions.NumberOfRejectedTrainees(year);

            return Ok(GetNumberOfRejectedTrainees);
        }

    }
}
