using ParkwaylabsExercise2.BusinessLogic.Interfaces;
using ParkwaylabsExercise2.ModelFactory;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.BusinessLogic
{
    public class TechLead_TechnologyManager: ITechLead_TechnologyManager
    {
        internal ITechLead_TechnologyRepository _techLead_TechnologyRepository;

        public TechLead_TechnologyManager(ITechLead_TechnologyRepository techLead_TechnologyRepository)
        {
            _techLead_TechnologyRepository = techLead_TechnologyRepository;
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            return await _techLead_TechnologyRepository.GetExperiencedTechLeadByTechnology(technologyName);
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology
            (int developerId, int technologyId)
        {
            return await _techLead_TechnologyRepository.GetExperiencedTechLeadByDeveloperTechnology
                (developerId, technologyId);
        }
    }
}
