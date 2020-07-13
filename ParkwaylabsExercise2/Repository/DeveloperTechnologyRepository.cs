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
    public class DeveloperTechnologyRepository : IDeveloperTechnologyRepository
    {
        private readonly DevTeamDBContext context;
        private readonly IUnitOfWork unitOfWork;

        public DeveloperTechnologyRepository(DevTeamDBContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<DeveloperTechnology>> GetDeveloperByTechnology(string technologyName)
        {
            return await context.DeveloperTechnology
                .Include(d => d.Developer)
                .Include(n => n.Technology)
                .Where(t => t.Technology.Name == technologyName).OrderByDescending(e => e.ExpLevel).ToListAsync();
        }
    }
}
