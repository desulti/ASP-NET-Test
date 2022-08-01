using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ESEIM.Models
{
    [Table("API_TOKEN_SERVICES")]
    public class ApiTokenService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Key { get; set; }

        public int? Limit { get; set; }

        [StringLength(50)]
        public string ServiceType { get; set; }

        [StringLength(255)]
        public string ApiSecret { get; set; }

        [StringLength(255)]
        public string Token { get; set; }

        public string AccountNumber { get; set; }

        [StringLength(255)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string UserRole { get; set; }

        [StringLength(255)]
        public string NameDisplay { get; set; }

        //[StringLength(50)]
        //public string Group { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(255)]
        public string SdkKey { get; set; }

        [StringLength(255)]
        public string SdkSecret { get; set; }

        public string CredentialsJson { get; set; }
        public string TokenJson { get; set; }
    }
}
