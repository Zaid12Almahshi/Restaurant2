using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterPartner: BaseEntity
    {
        [Required]
        public int MasterPartnerId { get; set; }
        [DisplayName("PartnerName")]
        public string MasterPartnerName { get; set; }
        [DisplayName("Logo")]
        public string MasterPartnerLogoImageUrl { get; set; }
        [DisplayName("WebsiteUrl")]
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
