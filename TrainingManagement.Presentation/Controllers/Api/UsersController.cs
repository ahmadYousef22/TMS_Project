using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrainingManagment.Domain.consts;
using TrainingManagment.Domain.Models;

namespace TrainingManagement.Presentation.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize(Roles = RoleName.Admin)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
       

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
            
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return NotFound();
            }

            //cascade on delete, meaning that when deleting a user all the roles and related data in other tables will deleted also
            // Restrict is different than cascade, you should delete all the related columns in other tables 
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception();
            }

            return Ok();

        }
    }
}
