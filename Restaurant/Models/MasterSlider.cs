using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterSlider: BaseEntity
    {
        [Required]
        public int MasterSliderId { get; set; }
        [DisplayName("SliderTitle")]
        public string MasterSliderTitle { get; set; }
        [DisplayName("SliderBreef")]
        public string MasterSliderBreef { get; set; }
        [DisplayName("SliderDesc")]
        public string MasterSliderDesc { get; set; }
        [DisplayName("Url")]
        public string MasterSliderUrl { get; set; }
    }
}
