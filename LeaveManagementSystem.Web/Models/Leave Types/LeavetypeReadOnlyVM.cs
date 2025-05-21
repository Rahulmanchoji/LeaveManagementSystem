using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.Leave_Types
{
    public class LeavetypeReadOnlyVM : BaseLeavetypeVM
    {
        public string Name { get; set; } = string.Empty;
       
        [Display(Name = "Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }
}
