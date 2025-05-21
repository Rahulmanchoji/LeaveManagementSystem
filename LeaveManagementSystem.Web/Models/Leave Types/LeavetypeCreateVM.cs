using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.Leave_Types
{
    public class LeavetypeCreateVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "You have Violated the Length Requirement")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1, 90)]
        [Display(Name="Maximum Allocation of Days")]
        public int NumberOfDays { get; set; }
    }

}