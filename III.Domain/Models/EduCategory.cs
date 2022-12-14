//------------------------------------------------------------------------------
// <auto-generated>
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESEIM.Models
{
    [Table("EDU_CATEGORY")]
    public class EduCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public int? Parent { get; set; }
        public int? ExtraFieldsGroup { get; set; }
        public bool? Published { get; set; }
        public int? Access { get; set; }
        public int? Ordering { get; set; }
        public string Image { get; set; }
        public string @Params { get; set; }
        public bool? Trash { get; set; }
        public string Plugins { get; set; }
        public string Language { get; set; }
        public string Template { get; set; }
        [NotMapped]
        public string Path { get; set; }
    }
}

