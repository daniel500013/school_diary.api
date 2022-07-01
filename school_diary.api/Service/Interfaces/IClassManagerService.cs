using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IClassManagerService
    {
        Task<List<UserClass>> GetAllClasses();
        Task<string> GetUserClass(string uuid);
        Task AddClass(UserClass userClass);
        Task PutClass(int id, UserClass userClass);
        Task DeleteUserClass(int id);
    }
}
