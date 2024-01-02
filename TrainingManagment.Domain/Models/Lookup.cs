using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrainingManagment.Domain.Models
{
    public class Lookup : BaseEntity
    {
        [Key]
        public int Id { get; set; }

         public int Code { get; set; }

        [Required] 
        public string NameEn { get; set; }

         public string NameAr { get; set; }

        public string Description { get; set; }
        [Required] 
        public int LookupCategoryId { get; set; }

        [ForeignKey("LookupCategoryId")]  
        public   LookupCategory LookupCategory { get; set; }


    }
}
