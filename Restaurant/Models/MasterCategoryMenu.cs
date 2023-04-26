using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterCategoryMenu: BaseEntity
    {

        [Required]
        public int MasterCategoryMenuId { get; set; }
        [DisplayName("Category Name")]
        public string MasterCategoryMenuName { get; set; }

       
    }
}
