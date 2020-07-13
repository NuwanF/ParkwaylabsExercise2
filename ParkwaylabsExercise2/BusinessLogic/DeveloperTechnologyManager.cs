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
    public class DeveloperTechnologyManager: IDeveloperTechnologyManager
    {
        internal IDeveloperTechnologyRepository developerTechnologyRepository;
        public DeveloperTechnologyManager(IDeveloperTechnologyRepository developerTechnologyRepository)
        {
            this.developerTechnologyRepository = developerTechnologyRepository;
        }
        public async Task<List<ExpLevelWiseDeveloper>> GetDeveloperByTechnology(string technologyName)
        {
            var result = await developerTechnologyRepository.GetDeveloperByTechnology(technologyName);

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
