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
    [Table("cms_roles")]
    public class cms_roles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public int? rank { get; set; }
        public DateTime? created { get; set; }
        public int? created_by { get; set; }
        public DateTime? modified { get; set; }
        public int? modified_by { get; set; }
    }
}
//namespace III.WebApp.Domain.DbContext
//{
//    using System;
//    using System.Collections.Generic;
    
//    public partial class cms_roles
//    {
//        public int id { get; set; }
//        public string name { get; set; }
//        public Nullable<int> rank { get; set; }
//        public Nullable<System.DateTime> created { get; set; }
//        public Nullable<int> created_by { get; set; }
//        public Nullable<System.DateTime> modified { get; set; }
//        public Nullable<int> modified_by { get; set; }
//    }
//}
