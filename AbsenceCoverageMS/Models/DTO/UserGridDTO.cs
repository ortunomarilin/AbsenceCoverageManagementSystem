using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DTO
{

    public class UserGridDTO : GridDTO
    {

        public string Search { get; set; } 

        public string Campus { get; set; } = "all";  // Has default value 

    }
}
