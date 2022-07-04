using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoles();
        Task<List<string>> GetUserRole(Guid uuid);
        Task AddRole(Role role);
        Task PutRole(int id, Role role);
        Task DeleteRole(int id);
    }
}
