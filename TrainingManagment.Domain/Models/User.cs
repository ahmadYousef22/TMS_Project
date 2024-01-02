using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingManagment.Domain.Models
{
    public class User: IdentityUser
    {
        [Required, MaxLength(120)]
        public string FullName { get; set; }

        public byte[] ProfilePicture { get; set; }

        
    }
}
