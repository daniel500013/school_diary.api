using school_diary.api.Model;

namespace school_diary.api.Service
{
    public class markService
    {
        private DiaryDbContext diaryDbContext { get; set; }

        public markService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<Marks>> GetAllMarks()
        {
            var marks = await diaryDbContext.marks.ToListAsync();

            return marks;
        }

        public async Task<List<Marks>> GetUserMarks(string uuid)
        {
            var marks = await diaryDbContext.marks
                .Include(x => x.Lesson)
                .Where(x => x.Lesson.UserId.ToString() == uuid)
                .ToListAsync();

            return marks;
        }

        public async Task AddMark(Marks mark)
        {
            if (mark is null)
            {
                throw new Exception("Invalid mark data model");
            }

            await diaryDbContext.AddAsync(mark);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutMark(int id, bool present)
        {
            if (id == 0)
            {
                throw new Exception("Invalid id or present data");
            }

            var newMark = await diaryDbContext.marks.SingleOrDefaultAsync(x => x.Id == id);

            if (newMark is null)
            {
                throw new Exception("Given mark dosen't exist");
            }

            newMark.Present = present;

            diaryDbContext.Update(newMark);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteMark(int id)
        {
            var markToDelete = await diaryDbContext.marks.FirstOrDefaultAsync(x => x.Id == id);

            if (markToDelete is null)
            {
                throw new Exception("Given mark dosen't exist");
            }

            diaryDbContext.Remove(markToDelete);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
