using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESEIM.Models
{
    [Table("ACTIVITY")]
    public class Activity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ActivityCode { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string Type { get; set; }
        public string WorkflowCode { get; set; }    
    }
}
