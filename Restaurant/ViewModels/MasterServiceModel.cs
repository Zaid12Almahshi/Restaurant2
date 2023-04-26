using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterServiceModel : BaseEntityModel
    {
        public int MasterServiceId { get; set; }
        public string MasterServiceTitle { get; set; }
        public string MasterServiceDesc { get; set; }
        public string MasterServiceLogo { get; set; }

        public string MasterServiceImage { get; set; }
        [DisplayName("Selsect Image")]
        public IFormFile File { get; set; }
        
    }
}
