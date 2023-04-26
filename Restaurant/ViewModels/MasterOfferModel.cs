using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterOfferModel : BaseEntityModel
    {
        public int MasterOfferId { get; set; }
        public string MasterOfferTitle { get; set; }
        public string MasterOfferBreef { get; set; }
        public string MasterOfferDesc { get; set; }
        public string MasterOfferImageUrl { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
