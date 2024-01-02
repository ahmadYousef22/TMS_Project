using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;

namespace TrainingManagement.Domain.ViewModels
{
    public class SessionSearchViewModel
    {
        public int SessionId { get; set; }

        public string Year { get; set; }

        public string Type { get; set; }

        public string Topic { get; set; }

        public string Status { get; set; }

        public string TrainerName { get; set; }

        public string TraineeName { get; set; }
        public string Result { get; set; }

        public List<Session> Sessions { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
    }
}
 
