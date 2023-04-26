using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Restaurant.ViewModels
{
    public class breadcrumb_areaModel:BaseEntityModel
    {
        public int breadcrumb_areaId { get; set; }
        public string breadcrumb_areaUrlImage { get; set; }
        public string breadcrumb_areaName { get; set; }
        public string Price { get; set; }
        public string Title { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }
    }
}
