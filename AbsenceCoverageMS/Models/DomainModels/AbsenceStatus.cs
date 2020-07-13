using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AbsenceStatusId { get; set; }

        public string Name { get; set; }


        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }

    }
}
