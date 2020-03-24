using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class ProcessingRequest
    {
        public string ProcessingRequestId { get; set; }

        [Required]
        public ProcessStatus Status { get; set; }
        
        [Required]
        public DateTime DateProcessed { get; set; }
        
        public string ProcessorComments { get; set; }

        [Required]
        public string Id { get; set; }
        public User User { get; set; }

    }
}

public enum ProcessStatus
{
    Submitted,
    Approved,
    Denied,
    Closed
}
