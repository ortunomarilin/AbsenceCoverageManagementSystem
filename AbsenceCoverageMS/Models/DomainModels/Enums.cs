using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Enums
    {
        public enum Duration
        {
            [Display(Name = "Full Day")]
            FullDay,
            [Display(Name = "Half Day")]
            HalfDay,
        }

        public enum Status
        {
            Submitted,
            Approved,
            Denied,
            Cancelled
        }

        public enum NeedCoverage
        {
            Yes,
            No
        }
    }
}
