﻿using System.ComponentModel;
using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.Web.Models.LeaveRequests
{
    public class ReviewLeaveRequestVM : LeaveRequestReadOnlyVM
    {
        public EmployeeListVM Employee { get; set; } = new EmployeeListVM();

        [DisplayName("Additional Information")]
        public string Requestcomments { get; set; }
    }
}