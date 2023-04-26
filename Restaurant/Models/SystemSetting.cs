using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

#nullable disable

namespace Restaurant.Models
{
    public partial class SystemSetting : BaseEntity
    {

        public int SystemSettingId { get; set; }
        [DisplayName("Logo 1")]
        public string SystemSettingLogoImageUrl { get; set; }
        [DisplayName("Logo 2")]
        public string SystemSettingLogoImageUrl2 { get; set; }
        [DisplayName("Copyright")]
        public string SystemSettingCopyright { get; set; }
        
        [DisplayName("Welcome Note Title")]
        public string SystemSettingWelcomeNoteTitle { get; set; }
        
        [DisplayName("Welcome Note Breef")]
        public string SystemSettingWelcomeNoteBreef { get; set; }
        [DisplayName("Welcome Note Desc")]
        public string SystemSettingWelcomeNoteDesc { get; set; }
        [DisplayName("Welcome Note Url")]
        public string SystemSettingWelcomeNoteUrl { get; set; }
        [DisplayName("Welcome Note Image")]
        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        [DisplayName("Map Location")]
        public string SystemSettingMapLocation { get; set; }
        [DisplayName("Phone Number")]
        public string SystemSettingPhoneNumber { get; set; }
        [DisplayName("Email")]
        public string SystemSettingEmail { get; set; }





    }
}
