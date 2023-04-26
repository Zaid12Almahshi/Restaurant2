using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class TransactionBookTable: BaseEntity
    {
        [Required]
        public int TransactionBookTableId { get; set; }
        [DisplayName("Full Name")]
        public string TransactionBookTableFullName { get; set; }
        [DisplayName("Email")]
        public string TransactionBookTableEmail { get; set; }
        [DisplayName("Mobile Number")]
        public string TransactionBookTableMobileNumber { get; set; }
        [DisplayName("Date")]
        public DateTime? TransactionBookTableDate { get; set; }
        [DisplayName("Title")]
        public string TransactionBookTableTitle { get; set; }
    }
}
