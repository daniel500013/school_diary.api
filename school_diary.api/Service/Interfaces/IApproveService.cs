using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IApproveService
    {
        Task<List<Approve>> GetAllApproves();
        Task<List<Approve>> GetUserApproves(string uuid);
        Task AddApprove(Approve approve);
        Task PutApprove(int id, Approve approve);
        Task DeleteApprove(int id);
    }
}
