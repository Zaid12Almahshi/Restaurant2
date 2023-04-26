using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant.Models
{
    public partial class TransactionNewsletter: BaseEntity
    {
        [Required]
        public int TransactionNewsletterId { get; set; }
        [DisplayName("Email")]
        public string TransactionNewsletterEmail { get; set; }

        public string TransactionNewsletterDec { get; set; }
    }
}
