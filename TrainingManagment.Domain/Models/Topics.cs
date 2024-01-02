using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;

namespace TrainingManagement.Domain.Models
{
   public  class Topics:BaseEntity
    {
        [Key]
        public int TopicId  { get; set; }

        public string  Name { get; set; }

        public ICollection<Trainer> Trainers { get; set; }
    }
}
