using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IAccountService
    {
        Task<List<User>> GetAllUsers();
        Task Register(User user);
        Task<string> Login(Login userModel);
    }
}
