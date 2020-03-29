using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Campus
    {
        public string CampusId { get; set; }  
        
        [Required]
        public string Name { get; set; }  
        [Required]
        public string StreetAddress { get; set; } 
        [Required]
        public string City { get; set; }  
        [Required]
        public States State { get; set; }
        [Required]
        public string ZipCode { get; set; }

        [Required]  //Manager of Campus
        public string Id { get; set; }    //FK


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

