using school_diary.api.Model;
using school_diary.api.Service.Interfaces;

namespace school_diary.api.Service
{
    public class classManagerService : IClassManagerService
    {
        private DiaryDbContext diaryDbContext;
        public classManagerService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<UserClass>> GetAllClasses()
        {
            var classes = await diaryDbContext.userClass.ToListAsync();

            return classes;
        }

        public async Task<string> GetUserClass(string uuid)
        {
            var userClass = await diaryDbContext.user
                .Include(x => x.userClass)
                .FirstOrDefaultAsync(x => x.uuid.ToString() == uuid);

            if (userClass is null)
            {
                throw new Exception("Given uuid dosen't exist");
            }

            string userClassToReturn = userClass.userClass.userClass + userClass.userClass.userClassProfile;

            return userClassToReturn;
        }

        public async Task AddClass(UserClass userClass)
        {
            if (userClass is null)
            {
                throw new Exception("Invalid UserClass data model");
            }

            await diaryDbContext.AddAsync(userClass);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutClass(int id, UserClass userClass)
        {
            if (userClass is null)
            {
                throw new Exception("Invalid UserClass data model");
            }

            var newUserClass = await diaryDbContext.userClass
                .FirstOrDefaultAsync(x => x.Id == id);

            if (newUserClass is null)
            {
                throw new Exception("Given id dosen't exist");
            }

            newUserClass.userClass = userClass.userClass;
            newUserClass.userClassProfile = userClass.userClassProfile;

            diaryDbContext.Update(newUserClass);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserClass(int id)
        {
            if (id.Equals(0))
            {
                throw new Exception("Given id equal 0");
            }

            var userClassToDelete = await diaryDbContext.userClass
                .FirstOrDefaultAsync(x => x.Id == id);

            if (userClassToDelete is null)
            {
                throw new Exception("Given id dosen't exist");
            }

            diaryDbContext.Remove(userClassToDelete);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
