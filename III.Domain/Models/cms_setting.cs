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
    [Table("cms_setting")]
    public class cms_setting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool? published { get; set; }
        public int? ordering { get; set; }
    }
}
//namespace III.WebApp.Domain.DbContext
//{
//    using System;
//    using System.Collections.Generic;
    
//    public partial class cms_setting
//    {
//        public int id { get; set; }
//        public string name { get; set; }
//        public string value { get; set; }
//        public Nullable<bool> published { get; set; }
//        public Nullable<int> ordering { get; set; }
//    }
//}
