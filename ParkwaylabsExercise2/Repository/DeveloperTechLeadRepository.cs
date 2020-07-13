using Microsoft.EntityFrameworkCore;
using ParkwaylabsExercise2.Data;
using ParkwaylabsExercise2.Models;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository
{
    public class DeveloperTechLeadRepository: IDeveloperTechLeadRepository
    {
        private readonly DevTeamDBContext context;
        private readonly IUnitOfWork unitOfWork;

        public DeveloperTechLeadRepository(DevTeamDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Developer_TechLead>> GetByDevelper(int developerId)
        {
            return await context.Developer_TechLead
                        .Where(x => x.DeveloperId == developerId).ToListAsync();

        }
    }
}
