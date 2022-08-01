using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ESEIM.Models
{
    [Table("WEEK_WORKING_SCHEDULER")]
    public class WeekWorkingScheduler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        public string WorkContent { get; set; }

        [NotMapped]
        public string Chair { get; set; }

        [NotMapped]
        public string Room { get; set; }
        [NotMapped]
        public string Composition { get; set; }

        [StringLength(20)]
        public string TimeStart { get; set; }

        [StringLength(20)]
        public string TimeEnd { get; set; }
        public string ListUserApproved { get; set; }
        public string JsonStatus { get; set; }
        public string Location { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }
        public string JsonRef { get; set; }

        public DateTime CreatedTime { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
        [StringLength(50)]
        public string ListUserUpProve { get; set; }
        public string JsonREF { get; set; }

    }
}
