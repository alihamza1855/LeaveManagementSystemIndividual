namespace LeaveManagementSystemIndividual.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
            RequestId = "100";
        }
        public string RequestId { get; set; }
        public bool ShowRequestId => string.IsNullOrWhiteSpace(RequestId);
    }
}
