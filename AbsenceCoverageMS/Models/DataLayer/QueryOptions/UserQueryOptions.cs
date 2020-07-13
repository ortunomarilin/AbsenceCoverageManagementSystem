using AbsenceCoverageMS.Models.DomainModels;
using AbsenceCoverageMS.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DataLayer.QueryOptions
{
    public class UserQueryOptions : QueryOptions<User>
    {

        public void Search(UserGridBuilder gridBuilder)
        {
            if(gridBuilder.CurrentGrid.Search != null)
            {
                string searchTerm = gridBuilder.CurrentGrid.Search.ToLower();
                Where = u => u.FirstName.ToLower().Contains(searchTerm) || u.LastName.ToLower().Contains(searchTerm) || u.UserName.ToLower().Contains(searchTerm); 
            }
        }

        public void Filter(UserGridBuilder gridBuilder)
        {
            //Filter by Campus 
            if(gridBuilder.CurrentGrid.Campus != "all")
            {
                Where = u => u.CampusId == gridBuilder.CurrentGrid.Campus;
            }
        }


        public void Sort(UserGridBuilder gridBuilder)
        {
            switch (gridBuilder.CurrentGrid.SortBy)
            {
                case nameof(User.FirstName):
                    OrderBy = u => u.FirstName;
                    break;
                case nameof(User.UserName):
                    OrderBy = u => u.UserName;
                    break;
                case nameof(User.Campus.Name):
                    OrderBy = u => u.Campus.Name;
                    break;
                default:
                    OrderBy = u => u.FirstName;
                    break;
            }

        }

    }
}
