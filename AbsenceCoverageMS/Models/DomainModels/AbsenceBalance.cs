using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceBalance
    {
        public string AbsenceBalanceId { get; set; }

        [Required]
        public string LeaveTypeId { get; set; }

        [Required]
        public int Granted { get; set; }

        public int Used { get; set; }

        public int Balance { get; set; }

        [Required]
        public string Id { get; set; }
        public User User { get; set; }
    }
}
