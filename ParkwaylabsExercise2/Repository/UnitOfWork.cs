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
        private BaseRepository<Developer_TechLead> _developer_TechLeads;
        private BaseRepository<Developer_Technology> _developer_Technologies;
        private BaseRepository<TechLead_Technology> _techLead_Technologies;

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

        public IBaseRepository<Developer_TechLead> Developer_TechLeads
        {
            get
            {
                return _developer_TechLeads ??
                    (_developer_TechLeads = new BaseRepository<Developer_TechLead>(_context));
            }
        }

        public IBaseRepository<Developer_Technology> Developer_Technologies
        {
            get
            {
                return _developer_Technologies ??
                    (_developer_Technologies = new BaseRepository<Developer_Technology>(_context));
            }
        }

        public IBaseRepository<TechLead_Technology> TechLead_Technologies
        {
            get
            {
                return _techLead_Technologies ??
                    (_techLead_Technologies = new BaseRepository<TechLead_Technology>(_context));
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
