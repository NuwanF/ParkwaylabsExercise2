using ParkwaylabsExercise2.Data;
using ParkwaylabsExercise2.Models;
using ParkwaylabsExercise2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DevTeamDBContext context;
        private BaseRepository<Developer> developer;
        private BaseRepository<TechLead> techLeads;
        private BaseRepository<Technology> technologies;
        private BaseRepository<DeveloperTechLead> developerTechLeads;
        private BaseRepository<DeveloperTechnology> developerTechnologies;
        private BaseRepository<TechLeadTechnology> techLeadTechnologies;

        public UnitOfWork(DevTeamDBContext context)
        {
            this.context = context;
        }

        public IBaseRepository<Developer> Developers
        {
            get
            {
                return developer ??
                    (developer = new BaseRepository<Developer>(context));
            }
        }

        public IBaseRepository<TechLead> TechLeads
        {
            get
            {
                return techLeads ??
                    (techLeads = new BaseRepository<TechLead>(context));
            }
        }

        public IBaseRepository<Technology> Technologies
        {
            get
            {
                return technologies ??
                    (technologies = new BaseRepository<Technology>(context));
            }
        }

        public IBaseRepository<DeveloperTechLead> DeveloperTechLeads
        {
            get
            {
                return developerTechLeads ??
                    (developerTechLeads = new BaseRepository<DeveloperTechLead>(context));
            }
        }

        public IBaseRepository<DeveloperTechnology> DeveloperTechnologies
        {
            get
            {
                return developerTechnologies ??
                    (developerTechnologies = new BaseRepository<DeveloperTechnology>(context));
            }
        }

        public IBaseRepository<TechLeadTechnology> TechLeadTechnologies
        {
            get
            {
                return techLeadTechnologies ??
                    (techLeadTechnologies = new BaseRepository<TechLeadTechnology>(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
