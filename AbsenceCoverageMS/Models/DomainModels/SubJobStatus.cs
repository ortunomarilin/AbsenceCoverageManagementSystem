using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class SubJobStatus
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubJobStatusId { get; set; }

        public string Name { get; set; }

        public ICollection<SubJob> SubJobs{ get; set; }
    }
}
