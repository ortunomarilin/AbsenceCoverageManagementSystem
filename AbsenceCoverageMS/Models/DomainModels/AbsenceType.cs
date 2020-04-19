using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceType
    {
        public string AbsenceTypeId { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }


        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }

    }
}
