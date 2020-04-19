using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Campus
    {
        public string CampusId { get; set; }  
        
        
        [Required(ErrorMessage ="Campus Name is required. ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Campus Phone number is required. ")]
        public string Phone { get; set; }

     
        [Required(ErrorMessage = "Street Address is required. ")]
        public string StreetAddress { get; set; }

        
        [Required(ErrorMessage = "City is required. ")]
        public string City { get; set; }

        
        [Required(ErrorMessage = "State is required. ")]
        public States State { get; set; }

       
        [Required(ErrorMessage = "Zip-Code is required. ")]
        public string ZipCode { get; set; }


        public ICollection<User> Users { get; set; }  //Nav
    }
}

public enum States
{
    AK,
    AZ,
    AR,
    CA,
    CO,
    CT,
    DE,
    FL,
    GA,
    HI,
    ID,
    IL,
    IN,
    IA,
    KS,
    KY,
    LA,
    ME,
    MD,
    MA,
    MI,
    MN,
    MS,
    MO,
    MT,
    NE,
    NV,
    NH,
    NJ,
    NM,
    NY,
    NC,
    ND,
    OH,
    OK,
    OR,
    PA,
    RI,
    SC,
    SD,
    TN,
    TX,
    UT,
    VT,
    VA,
    WA,
    WV,
    WI,
    WY
}

