﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoradoB2BCoreContext.Models
{
    public partial class Audit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public string FullTableName { get; set; }
        [Column("PK")]
        public string Pk { get; set; }
        [Required]
        public string JsonData { get; set; }
        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime AuditDate { get; set; }
        [Required]
        [StringLength(16)]
        public string AuditAction { get; set; }
        [Required]
        [Column("AuditIP")]
        [StringLength(32)]
        public string AuditIp { get; set; }
    }
}