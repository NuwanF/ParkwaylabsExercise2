using Microsoft.EntityFrameworkCore;
using ParkwaylabsExercise2.Data;
using ParkwaylabsExercise2.ModelFactory;
using ParkwaylabsExercise2.Models;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository
{
    public class TechLead_TechnologyRepository: ITechLead_TechnologyRepository
    {
        private readonly DevTeamDBContext _context;
        private readonly IUnitOfWork _unitOfWork;
        internal IDeveloper_TechnologyRepository _developer_TechnologyRepository;
        internal IDeveloper_TechLeadRepository _developer_TechLeadRepository;
        public TechLead_TechnologyRepository(DevTeamDBContext context, IUnitOfWork unitOfWork,
            IDeveloper_TechnologyRepository developer_TechnologyRepository,
            IDeveloper_TechLeadRepository developer_TechLeadRepository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _developer_TechnologyRepository = developer_TechnologyRepository;
            _developer_TechLeadRepository = developer_TechLeadRepository;
        }
        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            var techLead_TechnologyList = await _context.TechLead_Technology
                .Include(d => d.TechLead)
                .Include(n => n.Technology)
                .Where(t => t.Technology.Name == technologyName).OrderByDescending(e => e.ExpLevel).ToListAsync();

            if (techLead_TechnologyList.Count == 0)
            {
                return null;
            }

            var developer_TechnologyList = await _developer_TechnologyRepository.GetDeveloperByTechnology(technologyName);

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLead_Technology in techLead_TechnologyList)
            {
                var devList = _context.Developer_TechLead.Where(x => x.TechLeadId == techLead_Technology.TechLeadId).ToList();

                var exp = 0.00;
                var devCount = 0;
                foreach (var dev in devList)
                {
                    var devtech = developer_TechnologyList.Where(x => x.DeveloperId == dev.DeveloperId).FirstOrDefault();
                    if (devtech != null)
                    {
                        exp = exp + devtech.ExpLevel;
                        devCount++;
                    }
                }

                if (devList.Count > 0 && exp > 0)
                {
                    AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                    {
                        TechLeadName = techLead_Technology.TechLead.Name,
                        AverageScore = (techLead_Technology.ExpLevel + (exp / devCount)) / 2
                    };
                    averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
                }
                else
                {
                    AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                    {
                        TechLeadName = techLead_Technology.TechLead.Name,
                        AverageScore = techLead_Technology.ExpLevel
                    };
                    averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
                }
            }

            return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology
            (int developerId, int technologyId)
        {
            var filteredDeveloper_TechLeadList = await _developer_TechLeadRepository.GetByDevelper(developerId);

            var techLead_TechnologyList = await _context.TechLead_Technology
                .Include(d => d.TechLead)
                .Where(t => t.Technology.TechnologyId == technologyId).OrderByDescending(e => e.ExpLevel).ToListAsync();

            var filteredTechLead_TechnologyList = techLead_TechnologyList
                .Where(x => filteredDeveloper_TechLeadList.Any(y => y.TechLeadId == x.TechLeadId)).ToList();

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLead_Technology in filteredTechLead_TechnologyList)
            {
                AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                {
                    TechLeadName = techLead_Technology.TechLead.Name,
                    AverageScore = techLead_Technology.ExpLevel
                };
                averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
            }

            return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
        }
    }

}
