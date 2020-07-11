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
    public class Developer_TechLeadRepository: IDeveloper_TechLeadRepository
    {
        private readonly DevTeamDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public Developer_TechLeadRepository(DevTeamDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Developer_TechLead>> GetByDevelperAndTechLeadAsync(
            List<Developer_Technology> developer_TechnologyList, List<TechLead_Technology> techLead_TechnologyList)
        {
            return await _context.Developer_TechLead
                .Where(x => techLead_TechnologyList.Any(y => y.TechLeadId == x.TechLeadId))
                .Where(x => developer_TechnologyList.Any(y => y.DeveloperId == x.DeveloperId)).ToListAsync();

        }
    }
}
