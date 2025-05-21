using LeaveManagementSystem.Web.Models.Leave_Types;

namespace LeaveManagementSystem.Web.Services
{
    public interface ILeavetypesService
    {
        Task<bool> CheckIfLeavetypeNameExists(string name);
        Task<bool> CheckIfLeavetypeNameExistsForEdit(LeavetypeEditVM leavetypeEdit);
        Task Create(LeavetypeCreateVM model);
        Task Edit(LeavetypeEditVM model);
        Task<T> Get<T>(int Id) where T : class;
        Task<List<LeavetypeReadOnlyVM>> GetAll();
        bool LeavetypeExists(int id);
        Task Remove(int Id);
    }
}