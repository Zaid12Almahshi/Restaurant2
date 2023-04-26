using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterContactUsInformationModel : BaseEntityModel
    {
        public int MasterContactUsInformationId { get; set; }
        public string MasterContactUsInformationIdesc { get; set; }
        public string MasterContactUsInformationImageUrl { get; set; }
        public string MasterContactUsInformationRedirect { get; set; }

        public string MasterContactUsInformationTitle { get; set; }
        [DisplayName("select Image")]
        public IFormFile File { get; set; }
    }
}
