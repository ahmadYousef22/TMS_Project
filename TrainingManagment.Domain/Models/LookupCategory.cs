using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingManagment.Domain.Models
{
    public class LookupCategory : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required] 
        public string NameEn { get; set; }

        public string NameAr { get; set; }
        public string Description { get; set; }
        // Navigation property to refer to the collection of LookUps in this category
        public ICollection<Lookup> Lookups { get; set; }
    }
}
