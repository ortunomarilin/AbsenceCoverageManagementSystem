using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Course
    {
        public string CourseId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string PeriodId { get; set; }
        public Period Period { get; set; }

        
        [Required]
        public string Room { get; set; }
        
        //1 to Many 
        [Required]
        public string Id { get; set; }
        public User User { get; set; }

    }
}
