using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Areas.Admin.Models.ViewModels
{
    public class UserListViewModel
    {

        //For Current Route values 
        public GridDictionary Grid { get; set; }

        //For List of Users 
        public IEnumerable<User> Users { get; set; }


        //For DropDown Filter Select Lists 
        public IEnumerable<Campus> Campuses { get; set; }


        //For Total number of pages
        public double TotalPages { get; set; }


    }
}
