using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class TransactionContactUModel : BaseEntityModel
    {
        public int TransactionContactUId { get; set; }
        public string TransactionContactUFullName { get; set; }
        public string TransactionContactUEmail { get; set; }
        public string TransactionContactUSubject { get; set; }
        public string TransactionContactUMessage { get; set; }
    }
}
