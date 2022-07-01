using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface ILessonService
    {
        Task<List<Lesson>> GetAllLessons();
        Task<List<Lesson>> GetUserLessons(string uuid);
        Task AddLesson(Lesson lesson);
        Task PutLesson(int id, string lesson);
        Task DeleteLesson(int id);
    }
}
