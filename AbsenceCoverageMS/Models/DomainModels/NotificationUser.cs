using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AbsenceCoverageMS.Models.DomainModels
{
    public class NotificationUser
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }




    }
}
