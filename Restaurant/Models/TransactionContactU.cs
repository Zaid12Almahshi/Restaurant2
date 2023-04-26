using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class TransactionContactU: BaseEntity
    {
        [Required]
        public int TransactionContactUId { get; set; }
        [DisplayName("FullName")]
        public string TransactionContactUFullName { get; set; }
        [DisplayName("Email")]
        public string TransactionContactUEmail { get; set; }
        [DisplayName("Subject")]
        public string TransactionContactUSubject { get; set; }
        [DisplayName("Message")]
        public string TransactionContactUMessage { get; set; }
        [DisplayName("Title")]
        public string TransactionContactUTitle { get; set; }
    }
}
