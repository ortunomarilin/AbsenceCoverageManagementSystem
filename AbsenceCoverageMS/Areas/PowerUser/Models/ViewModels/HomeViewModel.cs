using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.PowerUser.Models.ViewModels
{
    public class HomeViewModel
    {

        public DateTime TodayDate { get; set; }


        //Report for 
        public DateTime StartDate { get; set; }


        //Employees Absencent  
        public int EmployeesAbsent { get; set; }


        //Absence Requests Unprocessed
        public int AbsencesNotProcessed { get; set; }


        //Filled - Coverage 
        public int Filled { get; set; }


        //Unfilled - Coverage
        public int Unfilled { get; set; }


    }
}
