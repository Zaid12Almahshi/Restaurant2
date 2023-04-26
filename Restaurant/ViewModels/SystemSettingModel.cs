using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Restaurant.ViewModels
{
    public class SystemSettingModel : BaseEntityModel
    {
        public int SystemSettingId { get; set; }
        public string SystemSettingLogoImageUrl { get; set; }
        public string SystemSettingLogoImageUrl2 { get; set; }
        public string SystemSettingCopyright { get; set; }
        public string SystemSettingWelcomeNoteTitle { get; set; }
        public string SystemSettingWelcomeNoteBreef { get; set; }
        public string SystemSettingWelcomeNoteDesc { get; set; }
        public string SystemSettingWelcomeNoteUrl { get; set; }
        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        public string SystemSettingMapLocation { get; set; }
        [DisplayName("Select Logo1")]
        public IFormFile File { get; set; }
        [DisplayName("Select Logo2")]
        public IFormFile File1 { get; set; }
        [DisplayName("Select Welcome Note Image")]
        public IFormFile File2 { get; set; }
        [DisplayName("Phone Number")]
        public string SystemSettingPhoneNumber { get; set; }
        [DisplayName("Email")]
        public string SystemSettingEmail { get; set; }

    }
}
