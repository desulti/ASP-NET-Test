//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESEIM.Models
{
    [Table("cms_attachments")]
    public class cms_attachments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int item_id { get; set; }
        public string file_name { get; set; }
        public string title { get; set; }
        public string title_attribute { get; set; }
        public int? hits { get; set; }
        public string file_url { get; set; }
        public string file_path { get; set; }
        public string file_type { get; set; }
    }
}

//namespace III.WebApp.Domain.DbContext
//{
//    using System;
//    using System.Collections.Generic;
    
//    public partial class cms_attachments
//    {
//        public int id { get; set; }
//        public int item_id { get; set; }
//        public string file_name { get; set; }
//        public string title { get; set; }
//        public string title_attribute { get; set; }
//        public Nullable<int> hits { get; set; }
//        public string file_url { get; set; }
//        public string file_path { get; set; }
//        public string file_type { get; set; }
//    }
//}
