using ParkwaylabsExercise2.ModelFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository.Interfaces
{
    public interface ITechLead_TechnologyRepository
    {
        Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByTechnology(string technologyName);

        Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology(int developerId, int technologyId);

    }
}
