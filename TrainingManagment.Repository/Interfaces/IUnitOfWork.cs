using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingManagment.Domain.Models;

namespace TrainingManagment.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
   
        ISessionsRepository Sessions { get; }
        ILookupRepository lookups { get; }
        void DetachEntity<TEntity>(TEntity entity) where TEntity : class;
        Task<int> Complete();
    }
}
