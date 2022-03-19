using System.ComponentModel;

namespace LeaveManagementSystemIndividual.ViewModels
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [DisplayName("Leave Type Name")]
        public string Name { get; set; }
        [DisplayName("Default Number Of Days")]
        public int DefaultDays { get; set; }
    }
}
