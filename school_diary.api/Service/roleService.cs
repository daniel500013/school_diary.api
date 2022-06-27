using school_diary.api.Model;

namespace school_diary.api.Service
{
    public class roleService
    {
        private DiaryDbContext diaryDbContext;
        public roleService(DiaryDbContext diaryDbContext)
        {
            this.diaryDbContext = diaryDbContext;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var roles = await diaryDbContext.role.ToListAsync();

            return roles;
        }

        public async Task<string> GetUserRole(string uuid)
        {
            var userRole = await diaryDbContext.user
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.uuid.ToString() == uuid);

            if (userRole is null)
            {
                throw new Exception("Given uuid dosen't exist");
            }

            return userRole.Role.Name;
        }

        public async Task AddRole(Role role)
        {
            if (role is null)
            {
                throw new Exception("Invalid role data model");
            }

            await diaryDbContext.AddAsync(role);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutRole(int id, Role role)
        {
            if (id.Equals(0))
            {
                throw new Exception("Given id equal 0");
            }

            var newRole = await diaryDbContext.role
                .FirstOrDefaultAsync(x => x.Id == id);

            if (newRole is null)
            {
                throw new Exception("Role dosen't exist");
            }

            newRole.Name = role.Name;

            diaryDbContext.Update(newRole);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
            var roleToDeletet = await diaryDbContext.role
                .FirstOrDefaultAsync(x => x.Id == id);

            if (roleToDeletet is null)
            {
                throw new Exception("Role dosen't exist");
            }

            diaryDbContext.Remove(roleToDeletet);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
