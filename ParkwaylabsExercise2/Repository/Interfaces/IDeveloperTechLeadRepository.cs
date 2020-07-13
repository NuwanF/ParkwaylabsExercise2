using ParkwaylabsExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository.Interfaces
{
    public interface IDeveloperTechLeadRepository
    {
        Task<List<DeveloperTechLead>> GetByDevelper(int developerId);
    }
}
