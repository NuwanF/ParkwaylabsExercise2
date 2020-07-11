﻿using ParkwaylabsExercise2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository.Interfaces
{
    public interface IDeveloper_TechLeadRepository
    {
        Task<List<Developer_TechLead>> GetByDevelperAndTechLeadAsync(
            List<Developer_Technology> developer_TechnologyList, List<TechLead_Technology> techLead_TechnologyList);
    }
}
