namespace LeaveManagementSystemIndividual.Models
{
    public class LeaveAllocation : BaseEntity
    {
        public int NoOfDays { get; set; }

        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public string EmployeeId { get; set; }
    }
}
