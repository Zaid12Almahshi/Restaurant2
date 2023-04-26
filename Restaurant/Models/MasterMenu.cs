using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterMenu: BaseEntity
    {
        [Required]
        public int MasterMenuId { get; set; }
        [DisplayName("MenuName")]
        public string MasterMenuName { get; set; }
        [DisplayName("Url")]
        public string MasterMenuUrl { get; set; }
    }
}
