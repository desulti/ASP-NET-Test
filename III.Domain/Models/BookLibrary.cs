using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESEIM.Models
{
    [Table("Book_Library")]
    public class BookLibrary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public string Kind { get; set; }
        public string Author { get; set; }
        public string Area { get; set; }
        public DateTime? Date { get; set; }
        public bool? Flag { get; set; }
    }
}
