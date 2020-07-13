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
    public class TechLeadTechnologyRepository: ITechLeadTechnologyRepository
    {
        private readonly DevTeamDBContext context;
        private readonly IUnitOfWork unitOfWork;
        internal IDeveloperTechnologyRepository developerTechnologyRepository;
        internal IDeveloperTechLeadRepository developerTechLeadRepository;
        public TechLeadTechnologyRepository(DevTeamDBContext context, IUnitOfWork unitOfWork,
            IDeveloperTechnologyRepository developerTechnologyRepository,
            IDeveloperTechLeadRepository developerTechLeadRepository)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.developerTechnologyRepository = developerTechnologyRepository;
            this.developerTechLeadRepository = developerTechLeadRepository;
        }
        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByTechnology(string technologyName)
        {
            var techLeadTechnologyList = await context.TechLead_Technology
                .Include(d => d.TechLead)
                .Include(n => n.Technology)
                .Where(t => t.Technology.Name == technologyName).OrderByDescending(e => e.ExpLevel).ToListAsync();

            if (techLeadTechnologyList.Count == 0)
            {
                return null;
            }

            var developerTechnologyList = await developerTechnologyRepository.GetDeveloperByTechnology(technologyName);

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLeadTechnology in techLeadTechnologyList)
            {
                var devList = context.Developer_TechLead.Where(x => x.TechLeadId == techLeadTechnology.TechLeadId).ToList();

                var exp = 0.00;
                var devCount = 0;
                foreach (var dev in devList)
                {
                    var devtech = developerTechnologyList.Where(x => x.DeveloperId == dev.DeveloperId).FirstOrDefault();
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
                        TechLeadName = techLeadTechnology.TechLead.Name,
                        AverageScore = (techLeadTechnology.ExpLevel + (exp / devCount)) / 2
                    };
                    averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
                }
                else
                {
                    AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                    {
                        TechLeadName = techLeadTechnology.TechLead.Name,
                        AverageScore = techLeadTechnology.ExpLevel
                    };
                    averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
                }
            }

            return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology
            (int developerId, int technologyId)
        {
            var filteredDeveloperTechLeadList = await developerTechLeadRepository.GetByDevelper(developerId);

            var techLeadTechnologyList = await context.TechLead_Technology
                .Include(d => d.TechLead)
                .Where(t => t.Technology.TechnologyId == technologyId).OrderByDescending(e => e.ExpLevel).ToListAsync();

            var filteredTechLeadTechnologyList = techLeadTechnologyList
                .Where(x => filteredDeveloperTechLeadList.Any(y => y.TechLeadId == x.TechLeadId)).ToList();

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLeadTechnology in filteredTechLeadTechnologyList)
            {
                AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                {
                    TechLeadName = techLeadTechnology.TechLead.Name,
                    AverageScore = techLeadTechnology.ExpLevel
                };
                averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
            }

            return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
        }
    }

}
