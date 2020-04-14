﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class AbsenceRequestPeriod
    {

        public string AbsenceRequestId {get; set;}
        public AbsenceRequest AbsenceRequest { get; set; }


        public string PeriodId { get; set; }
        public Period Period { get; set; }
    }
}
