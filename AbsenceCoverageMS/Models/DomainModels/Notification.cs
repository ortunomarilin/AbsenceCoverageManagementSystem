using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class Notification
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NotificationId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }


        public ICollection<NotificationUser> NotificationUsers { get; set; }


    }
}
