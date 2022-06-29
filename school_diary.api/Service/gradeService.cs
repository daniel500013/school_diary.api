using school_diary.api.Model;

namespace school_diary.api.Service
{
    public class gradeService
    {
        private DiaryDbContext diaryDbContext;

        public gradeService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<Grade>> GetAllGrades()
        {
            var grades = await diaryDbContext.grades.ToListAsync();

            return grades;
        }

        public async Task<List<Grade>> GetClassGrades(int classId)
        {
            var grades = await diaryDbContext.grades
                .Where(x => x.UserClassId == classId)
                .ToListAsync();

            if (grades.Count == 0)
            {
                throw new Exception("Given class dosen't exist");
            }

            return grades;
        }

        public async Task<List<Grade>> GetLessonClassGrades(int classId, int LessonId)
        {
            var getLessonName = await diaryDbContext.lesson
                .FirstOrDefaultAsync(x => x.Id == LessonId);

            if (getLessonName is null)
            {
                throw new Exception("Given lesson dosen't exist");
            }

            var grades = await diaryDbContext.grades
                .Include(x => x.Lesson)
                .Where(x => x.Lesson.Name == getLessonName.Name)
                .Where(x => x.UserClassId == classId)
                .ToListAsync();

            if (grades.Count == 0)
            {
                throw new Exception("Given class dosen't exist");
            }

            return grades;
        }

        public async Task<List<Grade>> GetUserGrades(string uuid)
        {
            if (uuid is null)
            {
                throw new Exception("Invalid uuid");
            }

            var userGrades = await diaryDbContext.grades
                .Include(x => x.Lesson)
                .Where(x => x.Lesson.UserId.ToString() == uuid)
                .ToListAsync();

            if (userGrades.Count == 0)
            {
                throw new Exception("Given user profile is empty");
            }

            return userGrades;
        }

        public async Task AddGrade(Grade grade)
        {
            if (grade is null)
            {
                throw new Exception("Invalid grade data model");
            }

            await diaryDbContext.AddAsync(grade);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutGrade(int gradeId, Grade grade)
        {
            if (grade is null)
            {
                throw new Exception("Invalid grade data model");
            }

            var newGrade = await diaryDbContext.grades
                .FirstOrDefaultAsync(x => x.Id == gradeId);

            if (newGrade is null)
            {
                throw new Exception("Given grade dosen't exist");
            }

            newGrade.Name = grade.Name;
            newGrade.Description = grade.Description;

            diaryDbContext.Update(newGrade);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteGrade(int gradeId)
        {
            if (gradeId.Equals(0))
            {
                throw new Exception("Given grade id is equal 0");
            }

            var gradeToDelete = await diaryDbContext.grades
                .FirstOrDefaultAsync(x => x.Id == gradeId);

            if (gradeToDelete is null)
            {
                throw new Exception("Grade dosen't exist");
            }

            diaryDbContext.Remove(gradeToDelete);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
