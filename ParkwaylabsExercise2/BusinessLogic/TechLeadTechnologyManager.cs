using ParkwaylabsExercise2.BusinessLogic.Interfaces;
using ParkwaylabsExercise2.ModelFactory;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.BusinessLogic
{
    public class TechLeadTechnologyManager: ITechLeadTechnologyManager
    {
        internal ITechLeadTechnologyRepository techLeadTechnologyRepository;

        public TechLeadTechnologyManager(ITechLeadTechnologyRepository techLeadTechnologyRepository)
        {
            this.techLeadTechnologyRepository = techLeadTechnologyRepository;
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            return await techLeadTechnologyRepository.GetExperiencedTechLeadByTechnology(technologyName);
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology
            (int developerId, int technologyId)
        {
            return await techLeadTechnologyRepository.GetExperiencedTechLeadByDeveloperTechnology
                (developerId, technologyId);
        }
    }
}
