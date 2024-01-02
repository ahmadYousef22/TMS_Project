using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;

namespace TrainingManagement.Domain.ViewModels
{
    public class AddLookupViewModel
    {
        [Key]
        public int Id { get; set; }

        public int Code { get; set; }

        [Required]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }

        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        public string Description { get; set; }
        [Required]
        public int LookupCategoryId { get; set; }

        [ForeignKey("LookupCategoryId")]  // Specify the foreign key relationship
        public LookupCategory LookupCategory { get; set; }
    }
}