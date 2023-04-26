using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterOffer: BaseEntity
    {
        [Required]
        public int MasterOfferId { get; set; }
        [DisplayName("OfferTitle")]
        public string MasterOfferTitle { get; set; }
        [DisplayName("OfferBreef")]
        public string MasterOfferBreef { get; set; }
        [DisplayName("OfferDesc")]
        public string MasterOfferDesc { get; set; }
        [DisplayName("Image")]
        public string MasterOfferImageUrl { get; set; }
    }
}
