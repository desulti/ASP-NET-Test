using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESEIM.Models
{
    [Table("MEETING_SCHEDULE")]
    public class MeetingSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string Comment { get; set; }

        public string AccountZoom { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public bool IsDeleted { get; set; }
        [NotMapped]
        public string Status { get; set; } // Not in use anymore
        public string JsonStatus { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }
        public string JsonRef { get; set; }
        [NotMapped]
        public List<UserApproved> ListUserObject { get; set; }
        public string ListUserApproved
        {
            get
            {
                return JsonConvert.SerializeObject(ListUserObject);
            }
            set
            {
                ListUserObject = string.IsNullOrEmpty(value)
                ? new List<UserApproved>()
                : JsonConvert.DeserializeObject<List<UserApproved>>(value);
            }
        }

        [NotMapped]
        public List<UserJoin> ListUsers { get; set; }
        [NotMapped]
        public string JsonData
        {
            get
            {
                return JsonConvert.SerializeObject(ListUsers);
            }
            set
            {
                ListUsers = string.IsNullOrEmpty(value)
                ? new List<UserJoin>()
                : JsonConvert.DeserializeObject<List<UserJoin>>(value);
            }
        }

    }

    public class UserApproved
    {
        public string userName { get; set; }
        public string status { get; set; }
    }

    public class MeetingScheduleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Comment { get; set; }

        public string AccountZoom { get; set; }
        public string Status { get; set; } // Not in use anymore

        public string JsonData { get; set; }
        public string ListUserApproved { get; set; }
        public string JsonStatus { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }
        public string JsonRef { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}