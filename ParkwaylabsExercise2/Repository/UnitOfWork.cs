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
        private DevTeamDBContext _context;
        private BaseRepository<Developer> _developer;
        private BaseRepository<TechLead> _techLeads;
        private BaseRepository<Technology> _technologies;
        private BaseRepository<DeveloperTechLead> _developer_TechLeads;
        private BaseRepository<DeveloperTechnology> _developer_Technologies;
        private BaseRepository<TechLeadTechnology> _techLead_Technologies;

        public UnitOfWork(DevTeamDBContext context)
        {
            _context = context;
        }

        public IBaseRepository<Developer> Developers
        {
            get
            {
                return _developer ??
                    (_developer = new BaseRepository<Developer>(_context));
            }
        }

        public IBaseRepository<TechLead> TechLeads
        {
            get
            {
                return _techLeads ??
                    (_techLeads = new BaseRepository<TechLead>(_context));
            }
        }

        public IBaseRepository<Technology> Technologies
        {
            get
            {
                return _technologies ??
                    (_technologies = new BaseRepository<Technology>(_context));
            }
        }

        public IBaseRepository<DeveloperTechLead> Developer_TechLeads
        {
            get
            {
                return _developer_TechLeads ??
                    (_developer_TechLeads = new BaseRepository<DeveloperTechLead>(_context));
            }
        }

        public IBaseRepository<DeveloperTechnology> Developer_Technologies
        {
            get
            {
                return _developer_Technologies ??
                    (_developer_Technologies = new BaseRepository<DeveloperTechnology>(_context));
            }
        }

        public IBaseRepository<TechLeadTechnology> TechLead_Technologies
        {
            get
            {
                return _techLead_Technologies ??
                    (_techLead_Technologies = new BaseRepository<TechLeadTechnology>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
