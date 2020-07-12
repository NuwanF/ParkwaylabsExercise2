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

        public async Task<List<Developer_TechLead>> GetByDevelper(int developerId)
        {
            return await _context.Developer_TechLead
                        .Where(x => x.DeveloperId == developerId).ToListAsync();

        }
    }
}
