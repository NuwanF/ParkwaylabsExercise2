using ParkwaylabsExercise2.ModelFactory;
using ParkwaylabsExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.BusinessLogic.Interfaces
{
    public interface IDeveloper_TechnologyManager
    {
        Task<List<ExpLevelWiseDeveloper>> GetDeveloperByTechnology(string technologyName);
    }
}
