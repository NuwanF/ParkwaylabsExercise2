using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkwaylabsExercise2.Models
{
    public class Developer_Technology
    {
        [Key, Column(Order = 0)]
        public int DeveloperId { get; set; }

        [Key, Column(Order = 1)]
        public int TechnologyId { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "Field can not be blank")]
        public int ExpLevel { get; set; }

        public virtual Developer Developer { get; set; }

        public virtual Technology Technology { get; set; }
    }
}
