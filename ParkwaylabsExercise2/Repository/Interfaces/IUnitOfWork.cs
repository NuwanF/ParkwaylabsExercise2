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
        IBaseRepository<DeveloperTechLead> DeveloperTechLeads { get; }
        IBaseRepository<DeveloperTechnology> DeveloperTechnologies { get; }
        IBaseRepository<TechLeadTechnology> TechLeadTechnologies { get; }
        void Commit();
    }
}
