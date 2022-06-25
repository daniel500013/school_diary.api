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

        public async Task<List<Lesson>> GetUserLessons(string uuid)
        {
            var userMakrs = await diaryDbContext.marks
                .Include(x => x.Lesson)
                .Include(x => x.User)
                .Where(x => x.User.uuid.ToString() == uuid)
                .ToListAsync();

            List<Lesson> lessons = new List<Lesson>();

            for(int i = 0; i < userMakrs.Count; i++)
            {
                var result = userMakrs[i].Lesson;

                lessons.Add(result);
            }

            return lessons;
        }
    }
}
