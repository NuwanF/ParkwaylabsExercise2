using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Models
{
    public class DeveloperTechLead
    {

        [Key, Column(Order = 0)]
        public int DeveloperId { get; set; }

        [Key, Column(Order = 1)]
        public int TechLeadId { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual TechLead TechLead { get; set; }

    }
}
