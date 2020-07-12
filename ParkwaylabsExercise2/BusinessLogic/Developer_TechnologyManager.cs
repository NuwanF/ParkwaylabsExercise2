using ParkwaylabsExercise2.BusinessLogic.Interfaces;
using ParkwaylabsExercise2.ModelFactory;
using ParkwaylabsExercise2.Models;
using ParkwaylabsExercise2.Repository;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.BusinessLogic
{
    public class Developer_TechnologyManager: IDeveloper_TechnologyManager
    {
        internal IDeveloper_TechnologyRepository _developer_TechnologyRepository;
        public Developer_TechnologyManager(IDeveloper_TechnologyRepository developer_TechnologyRepository)
        {
            _developer_TechnologyRepository = developer_TechnologyRepository;
        }
        public async Task<List<ExpLevelWiseDeveloper>> GetDeveloperByTechnology(string technologyName)
        {
            var result = await _developer_TechnologyRepository.GetDeveloperByTechnology(technologyName);

            List<ExpLevelWiseDeveloper> expLevelWiseDeveloperList = new List<ExpLevelWiseDeveloper>();
            foreach (var item in result)
            {
                ExpLevelWiseDeveloper expLevelWiseDeveloper = new ExpLevelWiseDeveloper()
                {
                    DeveloperName = item.Developer.Name,
                    ExpLevel = item.ExpLevel
                };
                expLevelWiseDeveloperList.Add(expLevelWiseDeveloper);
            }

            return expLevelWiseDeveloperList;
        }
    }
}
