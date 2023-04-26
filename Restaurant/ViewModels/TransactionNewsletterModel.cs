using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class TransactionNewsletterModel : BaseEntityModel
    {
        public int TransactionNewsletterId { get; set; }
        public string TransactionNewsletterEmail { get; set; }
    }
}
