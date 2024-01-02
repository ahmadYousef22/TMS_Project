using System;
using System.Collections.Generic;
using System.Text;
using TrainingManagment.Repository.Interfaces;
using TrainingManagment.Domain.Models;
using TrainingManagment.Repository.Data;
using System.Linq;
using TrainingManagment.Domain.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TrainingManagment.Repository.Repositories
{
    public class SessionsRepository : BaseRepository<Session>, ISessionsRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Session> GetSessionByYear(string year)
        {
            return (_context.Session.Where(x => x.Year == year).ToList());

        }
        public async Task UpdateSession(Session entity)
        {
            try
            {
                var existingEntity = _context.Set<Session>().Local.FirstOrDefault(e => e.SessionId == entity.SessionId);

                if (existingEntity != null)
                {
                     _context.Entry(existingEntity).State = EntityState.Detached;
                }

                var entityToUpdate = _context.Set<Session>().AsNoTracking().FirstOrDefault(e => e.SessionId == entity.SessionId);

                if (entityToUpdate != null)
                {
                    _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                    _context.Update(entityToUpdate);
                }
                else
                {
                    _context.Update(entity);
                }

            }
            catch (Exception ex)
            {
                throw new DataAccessException("An error occurred while updating the entity.", ex);
            }
        }

        public new Session GetByIdAsync(int id)
        {
        

            try
            {
                return   _context.Session.Where(x=>x.SessionId==id).FirstOrDefault()  ;
            }
            catch (DbUpdateException ex)
            {
                throw new DataAccessException("An error occurred while fetching an entity by ID.", ex);
            }
        }

        public int NumberOfTrainees()
        {
            return _context.Session.Where(x => x.IsActive).Count();

        }
        public int NumberOfTrainees(string status =null)
        {
            return _context.Session.Where(x=>x.IsActive && x.TrainingStatus.NameEn==status).Count();

         }
        public int NumberOfWorkedTrainees(string year )
        {
            return _context.Session.Where(x => x.TrainingResultId == (int)LookupEnum.Result.Joining_TPS_Team && x.IsActive && !x.IsDeleted).Count();

        }
        public int NumberOfAcceptedTrainees(string Year, string status = null)
        {

            var query = _context.Session.Where(x => x.TrainingResultId == (int)LookupEnum.Result.Joining_TPS_Team && x.Year == Year && x.IsActive == true); 

            if(!string.IsNullOrEmpty(status))
            {
                query= query.Where(x => x.TrainingStatus.NameEn == status);
            }

            return query.Count();
          }

        public int NumberOfRejectedTrainees(string Year, string status = null)
        {

            var query = _context.Session.Where(x => (x.TrainingResultId == (int)LookupEnum.Result.Rejected)  && x.Year == Year && x.IsActive);

            if (!string.IsNullOrEmpty(status))
            {
                query=query.Where(x => x.TrainingStatus.NameEn == status);
            }
            return query.Count();
        }


        public bool IsYearExist(string year)
        {
            var exist = _context.Session.Where(x => x.Year == year && x.IsActive == true);
            return exist.Any();
        }

        public List<Session> FindByYear(string year)
        {
            List < Session > sessions=_context.Session.Where(x => x.Year == year && x.IsActive == true).ToList();

            var sessionsWithLookup = _context.Session
             .Include(s => s.TrainingTopic)
            .Include(s => s.TrainingType)
             .Include(s => s.TrainerName)
            .ToList();


            return sessions;
        }

        public Session GetSession()
        {
            Session session = _context.Session.Where(s=>s.IsActive==true).FirstOrDefault();
     

            return session;
        }
    }
}