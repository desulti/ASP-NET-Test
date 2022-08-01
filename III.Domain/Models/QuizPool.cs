using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ESEIM.Models
{
	[Table("QUIZ_POOL")]
	public class QuizPool
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Code { get; set; }
        
        public string Title { get; set; }
		public string Content { get; set; }
        public int? Category { get; set; }
		public string JsonData { get; set; }
        [StringLength(50)]
		public string CreatedBy { get; set; }
		public DateTime? CreatedTime { get; set; }
		[StringLength(50)]
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedTime { get; set; }
		[StringLength(50)]
		public string DeletedBy { get; set; }
		public DateTime? DeletedTime { get; set; }
		public bool IsDeleted { get; set; }
        [NotMapped]
        public string QuestionCode { get; set; }
        [NotMapped]
        public int? Section { get; set; }
        [NotMapped]
        public int? Subject { get; set; }
        [NotMapped]
        public int? Course { get; set; }
        public string LectureRelative { get; set; }
		public int? Level { get; set; }
		public string LectureCode { get; set; }
		public int? Duration { get; set; }
		public string Unit { get; set; }
		public string SubjectCode { get; set; }
		public string Type { get; set; }
		public string JsonRef { get; set; }
		public string QuestionMedia { get; set; }
    }
}