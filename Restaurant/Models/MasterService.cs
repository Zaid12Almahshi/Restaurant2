using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterService : BaseEntity
    {
        [Required]
        public int MasterServiceId { get; set; }
        [DisplayName("ServiceTitle")]
        public string MasterServiceTitle { get; set; }
        [DisplayName("ServiceDesc")]
        public string MasterServiceDesc { get; set; }
        [DisplayName("Image")]
       public string MasterServiceImage { get; set; }
        [DisplayName("Logo")]
        public string MasterServiceLogo { get; set; }
    }
}
