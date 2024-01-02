using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingManagment.Domain.Models;

namespace TrainingManagment.Repository.Interfaces
{
    public interface ISessionsRepository : IBaseRepository<Session>
    {
        int NumberOfTrainees();

        int NumberOfTrainees( string status=null);
        int NumberOfWorkedTrainees(string year);
         int NumberOfAcceptedTrainees(string Year , string status=null);
          int NumberOfRejectedTrainees(string Year, string status = null);
        bool IsYearExist(string year);
        List<Session> FindByYear(string year);
         Session GetSession();

    }
}
