﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoradoB2BCoreContext.Models
{
    public partial class DataSendMail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string MailOdbiorca { get; set; }
        [StringLength(200)]
        public string MailTytul { get; set; }
        public string MailTresc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Data { get; set; }
        public bool IsErrorSend { get; set; }
        public string Error { get; set; }
    }
}