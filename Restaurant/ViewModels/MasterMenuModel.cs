using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterMenuModel : BaseEntityModel
    {
        public int MasterMenuId { get; set; }
        public string MasterMenuName { get; set; }
        public string MasterMenuUrl { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
