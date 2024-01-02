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

namespace TrainingManagment.Service.Sessions
{
    public class SessionService
    {
        private readonly ILogger<SessionService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SessionsRepository _context;
        public SessionService(ILogger<SessionService> logger, IUnitOfWork unitOfWork, SessionsRepository sessionsRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = sessionsRepository;
        }

        public async Task<IEnumerable<Session>> GetActiveSessionsForYear(string year)
        {
            try
            {
                return await _unitOfWork.Sessions.FindAllAsync(
                    s => s.IsActive && !s.IsDeleted && s.Year == year,
                    new[] { "TrainerName", "TrainingType", "TrainingTopic", "TrainingStatus" }
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving sessions.");
                throw;  
            }
        }

        public async Task<Session> GetSessionById(int id)
        {
            

           return (await _unitOfWork.Sessions.GetByIdAsync(id));

            
        }
        public async Task<bool> UpdateSession(Session session)
        {
            _unitOfWork.Sessions.Update(session);
            int EffectedRow= await _unitOfWork.Complete();
            return (EffectedRow > 0);
        }
        public async Task<bool> CreateSession(Session session)
        {
           await _unitOfWork.Sessions.AddAsync(session);
            int EffectedRow = await _unitOfWork.Complete();
            return (EffectedRow > 0);
        }

    }
}
