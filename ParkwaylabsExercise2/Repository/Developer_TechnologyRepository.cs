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
    public class Developer_TechnologyRepository : IDeveloper_TechnologyRepository
    {
        private readonly DevTeamDBContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public Developer_TechnologyRepository(DevTeamDBContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Developer_Technology>> GetDeveloperByTechnology(string technologyName)
        {
            return await _context.Developer_Technology
                .Include(d => d.Developer)
                .Include(n => n.Technology)
                .Where(t => t.Technology.Name == technologyName).OrderByDescending(e => e.ExpLevel).ToListAsync();
        }
    }
}
