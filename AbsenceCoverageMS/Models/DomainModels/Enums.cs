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
            FullDay = 1,
            HalfDay = 2
        }

        public enum Status
        {
            Submitted = 1,
            Approved = 2,
            Denied = 3,
            Cancelled = 4
        }

        public enum NeedCoverage
        {
            Yes = 1,
            No = 2
        }
    }
}
