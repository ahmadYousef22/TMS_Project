using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;
using TrainingManagment.Domain.ViewModels;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Repository.Repositories;

namespace TrainingManagment.Presentation
{
 
    public class MappingProfile
    {
        private readonly IUnitOfWork _unitOfWork;
         public MappingProfile(  IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

            public SessionViewModel MapSessionToViewModel(Session session)
        {
            return new SessionViewModel
            {
                SessionId = session.SessionId,
                StartDate = session.StartDate,
                ExpectedEndDate = session.ExpectedEndDate,
                ActualEndDate = session.ActualEndDate,
                Year = session.Year,
                TraineeName = session.TraineeName,
                FinalPresentationDate = session.FinalPresentationDate,
                EvaluationScore = session.EvaluationScore,
                Comment = session.Comment,
                TrainingResultId = session.TrainingResultId,
                TrainingTopicId = session.TrainingTopicId,
                TrainingTypeId = session.TrainingTypeId,
                TrainingStatusId = session.TrainingStatusId,
                TrainerNameId = session.TrainerNameId,
                TrainerName = session.TrainerName,
                TrainingStatus = session.TrainingStatus,
                TrainingResult = session.TrainingResult,
                TrainingTopic = session.TrainingTopic,
                TrainingType = session.TrainingType,
                ResultsList = _unitOfWork.lookups.GetAllResults(),
                TopicsList = _unitOfWork.lookups.GetAllTopics(),
                TypesList = _unitOfWork.lookups.GetAllTypes(),
                TrainersList = _unitOfWork.lookups.GetAllTrainer(),
                StatusList = _unitOfWork.lookups.GetAllStatus(),
                YearsList = _unitOfWork.lookups.GetAllYear(),
            };
        }

        public async Task<SessionViewModel> MapSessionToViewModelWithAll(Session session)
        {
            return new SessionViewModel
            {
                SessionId = session.SessionId,
                StartDate = session.StartDate,
                ExpectedEndDate = session.ExpectedEndDate,
                ActualEndDate = session.ActualEndDate,
                Year = session.Year,
                TraineeName = session.TraineeName,
                FinalPresentationDate = session.FinalPresentationDate,
                EvaluationScore = session.EvaluationScore,
                Comment = session.Comment,
                TrainingResultId = session.TrainingResultId,
                TrainingTopicId = session.TrainingTopicId,
                TrainingTypeId = session.TrainingTypeId,
                TrainingStatusId = session.TrainingStatusId,
                TrainerNameId = session.TrainerNameId,
                ResultsList = _unitOfWork.lookups.GetAllResults(),
                TopicsList = _unitOfWork.lookups.GetAllTopics(),
                TypesList = _unitOfWork.lookups.GetAllTypes(),
                TrainersList = _unitOfWork.lookups.GetAllTrainer(),
                StatusList = _unitOfWork.lookups.GetAllStatus(),
                YearsList = _unitOfWork.lookups.GetAllYear(),
                TrainerName = session.TrainerName,
                TrainingStatus = session.TrainingStatus,
                TrainingResult = session.TrainingResult,
                TrainingTopic = session.TrainingTopic,
                TrainingType = session.TrainingType,
                SessionsList = await _unitOfWork.Sessions.FindAllAsync(s => s.IsActive == true && s.IsDeleted == false, new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus", "TrainingResult" })


            };
        }

        public Session MapViewModelToSession(SessionViewModel viewModel)
        {
            return new Session
            {
                SessionId = viewModel.SessionId,
                StartDate = viewModel.StartDate,
                ExpectedEndDate = viewModel.ExpectedEndDate,
                ActualEndDate = viewModel.ActualEndDate,
                Year = viewModel.Year,
                TraineeName = viewModel.TraineeName,
                FinalPresentationDate = viewModel.FinalPresentationDate,
                EvaluationScore = viewModel.EvaluationScore,
                Comment = viewModel.Comment,
                TrainingResultId = viewModel.TrainingResultId,
                TrainingTopicId = viewModel.TrainingTopicId,
                TrainingTypeId = viewModel.TrainingTypeId,
                TrainingStatusId = viewModel.TrainingStatusId,
                TrainerNameId = viewModel.TrainerNameId,

            };
        }



    }
}
