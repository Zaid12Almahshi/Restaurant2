using Restaurant.Models;
using System.Collections.Generic;

namespace Restaurant.ViewModels
{
    public class HomeModel
    {
        public List<MasterMenu> MasterMenu { get; set; }
        public List<MasterSlider> MasterSlider { get; set; }
        public SystemSetting SystemSetting { get; set; }
        public List<MasterCategoryMenu> MasterCategoryMenu { get; set; }
        public List<MasterContactUsInformation> MasterContactUsInformation { get; set; }
        public List<MasterItemMenu> MasterItemMenu { get; set; }
        public MasterOffer MasterOffer { get; set; }
        public List<MasterPartner> MasterPartner { get; set; }
        public List<MasterService> MasterService { get; set; }
        public List<MasterSocialMedium> MasterSocialMedium { get; set; }
        public List<MasterWorkingHour> MasterWorkingHour { get; set; }
        public TransactionBookTable TransactionBookTable { get; set; }
        public TransactionContactU TransactionContactU { get; set; }
        public TransactionNewsletter TransactionNewsletter { get; set; }
        public List<breadcrumb_area> breadcrumb_area { get; set; }

    }
}
