using ParkwaylabsExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IBaseRepository<Developer> Developers { get; }
        IBaseRepository<TechLead> TechLeads { get; }
        IBaseRepository<Technology> Technologies { get; }
        IBaseRepository<Developer_TechLead> Developer_TechLeads { get; }
        IBaseRepository<Developer_Technology> Developer_Technologies { get; }
        IBaseRepository<TechLead_Technology> TechLead_Technologies { get; }
        void Commit();
    }
}
