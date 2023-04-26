using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterSocialMedium: BaseEntity
    {
        [Required]
        public int MasterSocialMediumId { get; set; }
        public string MasterSocialMediumName { get; set; }
        [DisplayName("Image")]

        public string MasterSocialMediumImageUrl { get; set; }
        [DisplayName("Url")]
        public string MasterSocialMediumUrl { get; set; }
    }
}
