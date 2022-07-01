using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IMarkService
    {
        Task<List<Marks>> GetAllMarks();
        Task<List<Marks>> GetUserMarks(string uuid);
        Task AddMark(Marks mark);
        Task PutMark(int id, bool present);
        Task DeleteMark(int id);
    }
}
