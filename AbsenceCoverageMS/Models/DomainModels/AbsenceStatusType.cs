using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceStatusType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AbsenceStatusTypeId { get; set; }

        public string Name { get; set; }


        public ICollection<AbsenceRequest> AbsenceRequests { get; set; }

    }
}
