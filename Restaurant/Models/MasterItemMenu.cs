using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterItemMenu: BaseEntity
    {
        [Required]
        public int MasterItemMenuId { get; set; }
        [DisplayName("CategoryMenu")]
        public int? MasterCategoryMenuId { get; set; }
        [DisplayName("ItemMenuTitle")]
        public string MasterItemMenuTitle { get; set; }
        [DisplayName("ItemMenuBreef")]
        public string MasterItemMenuBreef { get; set; }
        [DisplayName("ItemMenuDesc")]
        public string MasterItemMenuDesc { get; set; }
        [DisplayName("Price")]
        public decimal? MasterItemMenuPrice { get; set; }
        [DisplayName("Image")]
        public string MasterItemMenuImageUrl { get; set; }
       
        [DisplayName("Date")]
        public DateTime? MasterItemMenuDate { get; set; }

        public virtual MasterCategoryMenu MasterCategoryMenu { get; set; }
    }
}
