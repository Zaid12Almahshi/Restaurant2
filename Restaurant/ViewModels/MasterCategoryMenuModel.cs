using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Restaurant.ViewModels
{
    public class MasterCategoryMenuModel: BaseEntityModel
    {
        public int MasterCategoryMenuId { get; set; }
        
        public string MasterCategoryMenuName { get; set; }
    }
}
