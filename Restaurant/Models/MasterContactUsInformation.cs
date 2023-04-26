using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterContactUsInformation: BaseEntity
    {
        [Required]
        public int MasterContactUsInformationId { get; set; }
        [DisplayName("InformationIdesc")]
        public string MasterContactUsInformationIdesc { get; set; }
        [DisplayName("InformationImage")]
        public string MasterContactUsInformationImageUrl { get; set; }
        [DisplayName("InformationRedirect")]
        public string MasterContactUsInformationRedirect { get; set; }
        [DisplayName("Title")]
        public string MasterContactUsInformationTitle { get; set; }
    }
}
