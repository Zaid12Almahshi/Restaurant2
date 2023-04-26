using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class MasterWorkingHourModel : BaseEntityModel
    {
        public int MasterWorkingHourId { get; set; }
        public string MasterWorkingHourIdName { get; set; }
        public string MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
