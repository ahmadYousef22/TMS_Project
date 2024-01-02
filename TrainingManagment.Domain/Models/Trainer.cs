using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;

namespace TrainingManagement.Domain.Models
{
   public class Trainer:BaseEntity
    {
        public int TrainerId { get; set; }

        public string Name { get; set; }

        public ICollection<Topics> Topics { get; set; }

    }
}
