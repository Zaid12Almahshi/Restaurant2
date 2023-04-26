using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSocialMediumModel : BaseEntityModel
    {
        public int MasterSocialMediumId { get; set; }
        public string MasterSocialMediumName { get; set; }
        public string MasterSocialMediumImageUrl { get; set; }
        public string MasterSocialMediumUrl { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
