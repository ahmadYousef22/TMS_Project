using TrainingManagment.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using TrainingManagement.Domain.Models;

namespace TrainingManagment.Domain.Models
{
    public class Session : BaseEntity
    {
        [Key]
        public int SessionId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime ExpectedEndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ActualEndDate { get; set; }

        [Required]
        public string Year { get; set; }

        [Required]
        public string TraineeName { get; set; }


        [DataType(DataType.Date)]
        public DateTime? FinalPresentationDate { get; set; }

        public double? EvaluationScore { get; set; }

        public string? Comment { get; set; }

        // Navigation properties to refer to related Lookup entities
        [ForeignKey("TrainingResultId")]
        public Lookup TrainingResult { get; set; }
        public int? TrainingResultId { get; set; }

        [ForeignKey("TrainingTopicId")]
        public Lookup TrainingTopic { get; set; }
        public int? TrainingTopicId { get; set; }


        [ForeignKey("TrainingTypeId")]
        public Lookup TrainingType { get; set; }
        public int? TrainingTypeId { get; set; }


        [ForeignKey("TrainingStatusId")]
        public Lookup TrainingStatus { get; set; }

        public int? TrainingStatusId { get; set; }


        [ForeignKey("TrainerNameId")]
        public Lookup TrainerName { get; set; }
        public int? TrainerNameId { get; set; }

        public byte[]? EvaluationFile { get; set; }


        //[ForeignKey("TopicId")]
        //public Topics Topics { get; set; }
        //public int? TopicId { get; set; }


        //[ForeignKey("TrainerId")]
        //public Trainer Trainer { get; set; }
        //public int? TrainerId { get; set; }


    }

}
