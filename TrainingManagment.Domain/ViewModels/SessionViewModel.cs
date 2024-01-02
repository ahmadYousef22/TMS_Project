using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using TrainingManagment.Domain.Models;
using TrainingManagment.Domain.Models.Enums;

namespace TrainingManagment.Domain.ViewModels
{
    public class SessionViewModel
    {

        public int SessionId { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required.")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Expected End Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Expected End Date is required.")]
        public DateTime ExpectedEndDate { get; set; }

        [Display(Name = "Actual End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [DataType(DataType.Date)]
        public DateTime? ActualEndDate { get; set; }

        [Display(Name = "Year")]
        [Required(ErrorMessage = "Year is required.")]
        public string Year { get; set; }

        [Display(Name = "Trainee Name")]
        [Required(ErrorMessage = "Trainee Name is required.")]
        public string TraineeName { get; set; }

        [Display(Name = "Final Presentation Date")]
        [DataType(DataType.Date)]
        public DateTime? FinalPresentationDate { get; set; }

        [Display(Name = "Evaluation Score")]
        public double? EvaluationScore { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]

        public string Comment { get; set; }

        [Display(Name = "Training Result")]
        public int? TrainingResultId { get; set; }

        [Display(Name = "Training Topic")]
        public int? TrainingTopicId { get; set; }

        [Display(Name = "Training Type")]
        public int? TrainingTypeId { get; set; }

        [Display(Name = "Training Status")]
        public int? TrainingStatusId { get; set; }

        [Display(Name = "Trainer Name")]
        public int? TrainerNameId { get; set; }

        //for lookup list
        public List<Lookup> YearsList { get; set; }
        public List<Lookup> TypesList { get; set; }
        public List<Lookup> TopicsList { get; set; }
        public List<Lookup> TrainersList { get; set; }
        public List<Lookup> StatusList { get; set; }
        public List<Lookup> ResultsList { get; set; }

        //Navigation properties
        public Lookup TrainingResult { get; set; }
        public Lookup TrainingTopic { get; set; }
        public Lookup TrainingType { get; set; }
        public Lookup TrainingStatus { get; set; }
        public Lookup TrainerName { get; set; }
        public Lookup LookupYear { get; set; }

        public IEnumerable<Session> SessionsList { get; set; }

        public bool Isdeleted { get; set; } = false;
        [Display(Name = "Evaluation File")]

        public byte[]? EvaluationFile { get; set; }

        //public byte[]? EvaluationFileData { get; set; } // Store binary file content
        //public string? EvaluationFileName { get; set; } //
    }
}
