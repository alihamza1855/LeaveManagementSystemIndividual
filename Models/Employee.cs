using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystemIndividual.Models
{
    public class Employee : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }

    }
}
