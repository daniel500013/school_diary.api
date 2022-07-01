using school_diary.api.Model;

namespace school_diary.api.Service.Interfaces
{
    public interface IGradeService
    {
        Task<List<Grade>> GetAllGrades();
        Task<List<Grade>> GetClassGrades(int classId);
        Task<List<Grade>> GetLessonClassGrades(int classId, int LessonId);
        Task<List<Grade>> GetUserGrades(string uuid);
        Task AddGrade(Grade grade);
        Task PutGrade(int gradeId, Grade grade);
        Task DeleteGrade(int gradeId);
    }
}
