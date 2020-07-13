using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Models
{
    public class TechLead
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TechLeadId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Name { get; set; }

        public virtual ICollection<DeveloperTechLead> Developer_TechLeads { get; set; }

        public virtual ICollection<TechLeadTechnology> TechLead_Technologies { get; set; }

    }
}
