﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESEIM.Models
{
    [Table("LMS_TUTORING_SCHEDULE")]
    public class LmsTutoringSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public string Comment { get; set; }
        public string JsonStatus { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }

        public string AccountZoom { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        [StringLength(50)]
        public string UpdatedBy { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(100)]
        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public bool? IsPopupAllowed { get; set; }

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
        public List<Lecture> ListLectures { get; set; }

        public string LectureList
        {
            get
            {
                return JsonConvert.SerializeObject(ListLectures);
            }
            set
            {
                ListLectures = string.IsNullOrEmpty(value)
                ? new List<Lecture>()
                : JsonConvert.DeserializeObject<List<Lecture>>(value);
            }
        }

        [NotMapped]
        public List<Lesson> ListLessons { get; set; }

        public string LessonDoc
        {
            get
            {
                return JsonConvert.SerializeObject(ListLessons);
            }
            set
            {
                ListLessons = string.IsNullOrEmpty(value)
                ? new List<Lesson>()
                : JsonConvert.DeserializeObject<List<Lesson>>(value);
            }
        }
    }

    public class UserJoin
    {
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public DateTime? StartJoin { get; set; }
        public DateTime? EndJoin { get; set; }
    }
    public class Lecture
    {
        public string LectureId { get; set; }
        public string Title { get; set; }
        public string Session { get; set; }
        public string Subject { get; set; }
        public string Course { get; set; }
        public string Tutor { get; set; }
    }
    public class Lesson
    {
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string Subject { get; set; }
        public string FileTypePhysic { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedTime { get; set; }
    }

    public class LmsTutoringScheduleModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string StartTime { get; set; }
        public DateTime StartDateTime { get; set; }

        public string EndTime { get; set; }
        public string BackgroundColor { get; set; }
        public string BackgroundImage { get; set; }

        public string Comment { get; set; }

        public string AccountZoom { get; set; }

        public string ListUserApproved { get; set; }
        public string JsonStatus { get; set; }
        public bool? IsPopupAllowed { get; set; }

        public string LectureList { get; set; }

        public string LessonDoc { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}