using Microsoft.AspNetCore.Http;
using Restaurant.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterItemMenuModel : BaseEntityModel
    {
        public int MasterItemMenuId { get; set; }
        public int? MasterCategoryMenuId { get; set; }
        public string MasterItemMenuTitle { get; set; }
        public string MasterItemMenuBreef { get; set; }

        public string MasterItemMenuDesc { get; set; }
        public decimal? MasterItemMenuPrice { get; set; }
        public string MasterItemMenuImageUrl { get; set; }
        public DateTime? MasterItemMenuDate { get; set; }
        [DisplayName("Select Image")]
        public IFormFile File { get; set; }

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }
    }
}
