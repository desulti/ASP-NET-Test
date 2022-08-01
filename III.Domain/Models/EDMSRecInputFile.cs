﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESEIM.Models
{
    [Table("EDMS_RECEIPT_INPUT_FILE")]
    public class EDMSRecInputFile
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? RecId { get; set; }

        public int? FileId { get; set; }
    }
}
