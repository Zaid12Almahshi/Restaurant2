using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterPartnerModel : BaseEntityModel
    {
        public int MasterPartnerId { get; set; }
        public string MasterPartnerName { get; set; }
        public string MasterPartnerLogoImageUrl { get; set; }
        public string MasterPartnerWebsiteUrl { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
