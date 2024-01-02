using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Interfaces;

namespace TrainingManagment.Service.Lookups
{

    public class LookupService
    {

        private readonly IUnitOfWork _unitOfWork;

        public LookupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public IEnumerable<Lookup> GetActiveTopics()
        {
            return  _unitOfWork.lookups.GetAllTopics().ToList();
        }

        public IEnumerable<Lookup> GetActiveTypes()
        {
            return _unitOfWork.lookups.GetAllTypes().ToList();
        }

        public IEnumerable<Lookup> GetActiveStatus()
        {
            return _unitOfWork.lookups.GetAllStatus().ToList();
        }

        public IEnumerable<Lookup> GetActiveTrainers()
        {
            return _unitOfWork.lookups.GetAllTrainer().ToList();
        }

        public IEnumerable<Lookup> GetActiveResults()
        {
            return _unitOfWork.lookups.GetAllResults().ToList();
        }

        public IEnumerable<Lookup> GetActiveYears()
        {
            return _unitOfWork.lookups.GetAllYear().ToList();
        }


    }
}
