using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterSliderModel : BaseEntityModel
    {
        public int MasterSliderId { get; set; }
        public string MasterSliderTitle { get; set; }
        public string MasterSliderBreef { get; set; }
        public string MasterSliderDesc { get; set; }
        public string MasterSliderUrl { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
