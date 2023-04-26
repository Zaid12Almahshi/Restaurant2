using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class MasterWorkingHour: BaseEntity
    {
        public int MasterWorkingHourId { get; set; }
        [DisplayName("Name")]
        public string MasterWorkingHourIdName { get; set; }
        [DisplayName("TimeFormTo")]
        public string MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
