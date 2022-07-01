using school_diary.api.Model;

namespace school_diary.api.Service
{
    public class lessonService
    {
        private readonly DiaryDbContext diaryDbContext;

        public lessonService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            var listofAllLessons = await diaryDbContext.lesson.ToListAsync();

            return listofAllLessons;
        }

        public async Task<List<Lesson>> GetUserLessons(string uuid)
        {
            var userLessons = await diaryDbContext.lesson
                .Include(x => x.User)
                .Where(x => x.FK_UserUUID.ToString() == uuid)
                .ToListAsync();

            if (userLessons is null)
            {
                throw new Exception("Given uuid dosen't exist");
            }

            return userLessons;
        }

        public async Task AddLesson(Lesson lesson)
        {
            if (lesson is null)
            {
                throw new Exception("Invalid lesson data model");
            }

            await diaryDbContext.lesson.AddAsync(lesson);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutLesson(int id, string lesson)
        {
            var newLesson = await diaryDbContext.lesson.FirstOrDefaultAsync(x => x.Id == id);

            if (newLesson is null)
            {
                throw new Exception("Given lesson id dosen't exist");
            }

            newLesson.Name = lesson;

            diaryDbContext.Update(newLesson);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteLesson(int id)
        {
            var lessonToDelete = await diaryDbContext.lesson.SingleOrDefaultAsync(x => x.Id == id);

            if (lessonToDelete is null)
            {
                throw new Exception("Given lesson id dosen't exist");
            }

            diaryDbContext.Remove(lessonToDelete);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
