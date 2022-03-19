using LeaveManagementSystemIndividual.Contracts;
using LeaveManagementSystemIndividual.Data;
using LeaveManagementSystemIndividual.Models;

namespace LeaveManagementSystemIndividual.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
