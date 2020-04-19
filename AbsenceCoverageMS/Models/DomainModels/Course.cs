using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CourseId { get; set; }


        [Required(ErrorMessage = "A Course Name is required. ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "A Period number is required. ")]
        public string PeriodId { get; set; }
        public Period Period { get; set; }


        [Required(ErrorMessage = "A Room number is required. ")]
        public string Room { get; set; }


        [Required(ErrorMessage = "Teacher Name is required. ")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
