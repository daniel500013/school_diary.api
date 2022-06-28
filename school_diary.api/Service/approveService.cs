using school_diary.api.Model;

namespace school_diary.api.Service
{
    public class approveService
    {
        private DiaryDbContext diaryDbContext;

        public approveService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<Approve>> GetAllApproves()
        {
            var approves = await diaryDbContext.approves.ToListAsync();

            return approves;
        }

        public async Task<List<Approve>> GetUserApproves(string uuid)
        {
            if (string.IsNullOrEmpty(uuid))
            {
                throw new Exception("Invalid uuid");
            }

            var userApprove = await diaryDbContext.approves
                .Include(x => x.Lesson)
                .Where(x => x.Lesson.UserId.ToString() == uuid)
                .ToListAsync();

            if (userApprove.Count == 0)
            {
                throw new Exception("Given uuid dosen't exist in context");
            }

            return userApprove;
        }

        public async Task AddApprove(Approve approve)
        {
            if (approve is null)
            {
                throw new Exception("Given approve model is invalid");
            }

            await diaryDbContext.AddAsync(approve);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutApprove(int id, Approve approve)
        {
            if (id.Equals(0))
            {
                throw new Exception("Given id equal 0");
            }

            var newApprove = await diaryDbContext.approves
                .FirstOrDefaultAsync(x => x.Id == id);

            if (newApprove is null)
            {
                throw new Exception("Given approve dosen't exist in context");
            }

            newApprove.Positive = approve.Positive; 
            newApprove.Description = approve.Description;

            diaryDbContext.Update(newApprove);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteApprove(int id)
        {
            if (id.Equals(0))
            {
                throw new Exception("Give id equal 0");
            }

            var approveToDelete = await diaryDbContext.approves
                .FirstOrDefaultAsync(x => x.Id == id);

            if (approveToDelete is null)
            {
                throw new Exception("Given id dosen't exist in context");
            }

            diaryDbContext.Remove(approveToDelete);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
