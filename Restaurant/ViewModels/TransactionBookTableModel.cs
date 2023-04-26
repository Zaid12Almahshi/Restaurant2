using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class TransactionBookTableModel : BaseEntityModel
    {
        public int TransactionBookTableId { get; set; }
        public string TransactionBookTableFullName { get; set; }
        public string TransactionBookTableEmail { get; set; }
        public string TransactionBookTableMobileNumber { get; set; }
        public DateTime? TransactionBookTableDate { get; set; }
    }
}
