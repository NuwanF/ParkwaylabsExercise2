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

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLead_Technology in techLead_TechnologyList)
            {
                AverageScoreWiseTechLead averageScoreWiseTechLead = new AverageScoreWiseTechLead()
                {
                    TechLeadName = techLead_Technology.TechLead.Name,
                    AverageScore = techLead_Technology.ExpLevel
                };
                averageScoreWiseTechLeadList.Add(averageScoreWiseTechLead);
            }

            var developer_TechnologyList = await _developer_TechnologyRepository.GetDeveloperByTechnology(technologyName);
            if (developer_TechnologyList.Count == 0)
            {
                return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
            }

            var developer_TechLeadList = await _developer_TechLeadRepository.GetByDevelperAndTechLeadAsync
                (developer_TechnologyList, techLead_TechnologyList);

            foreach (var techLead_Technology in techLead_TechnologyList)
            {
                var filteredDeveloper_TechLeadList = developer_TechLeadList
                        .Where(x => x.TechLeadId == techLead_Technology.TechLeadId);

                var avgDev = developer_TechnologyList
                    .Where(x => filteredDeveloper_TechLeadList.Any(y => y.DeveloperId == x.DeveloperId))
                    .GroupBy(a => a.TechnologyId)
                    .Select(y => new
                    {
                        Quantity = y.Average(x => x.ExpLevel)
                    }).FirstOrDefault().Quantity;

                string techLeadName = techLead_TechnologyList
                    .Where(x => x.TechLeadId == techLead_Technology.TechLeadId)
                    .Select(y => y.TechLead.Name).FirstOrDefault();

                foreach (var item in averageScoreWiseTechLeadList.Where(w => w.TechLeadName == techLeadName))
                {
                    double avgTech = item.AverageScore;
                    item.AverageScore = (avgTech + avgDev) / 2;
                }

            }

            return averageScoreWiseTechLeadList.OrderByDescending(x => x.AverageScore).ToList();
        }

        public async Task<List<AverageScoreWiseTechLead>> GetExperiencedTechLeadByDeveloperTechnology
            (int developerId, int technologyId)
        {
            var filteredDeveloper_TechLeadList = await _context.Developer_TechLead
                        .Where(x => x.DeveloperId == developerId).ToListAsync();

            var techLead_TechnologyList = await _context.TechLead_Technology
                .Include(d => d.TechLead)
                .Include(n => n.Technology)
                .Where(t => t.Technology.TechnologyId == technologyId).OrderByDescending(e => e.ExpLevel).ToListAsync();

            var filteredTechLead_TechnologyList = techLead_TechnologyList
                .Where(x => techLead_TechnologyList.Any(y => y.TechLeadId == x.TechLeadId)).ToList();

            List<AverageScoreWiseTechLead> averageScoreWiseTechLeadList = new List<AverageScoreWiseTechLead>();
            foreach (var techLead_Technology in techLead_TechnologyList)
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
