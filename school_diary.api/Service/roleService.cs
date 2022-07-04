using school_diary.api.Model;
using school_diary.api.Service.Interfaces;

namespace school_diary.api.Service
{
    public class roleService : IRoleService
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

        public async Task<List<string>> GetUserRole(Guid uuid)
        {
            var userRole = await diaryDbContext.userRole
                .Include(x => x.Role)
                .Where(x => x.FK_UserId == uuid)
                .Select(r => r.Role.Name)
                .ToListAsync();

            return userRole;
        }

        public async Task AddRole(Role role)
        {
            if (role is null)
            {
                throw new ArgumentNullException("Invalid role data model");
            }

            await diaryDbContext.AddAsync(role);
            await diaryDbContext.SaveChangesAsync();
        }

        public async Task PutRole(int id, Role role)
        {
            if (id.Equals(0))
            {
                throw new IndexOutOfRangeException("Given id equal 0");
            }

            var newRole = await diaryDbContext.role
                .FirstOrDefaultAsync(x => x.Id == id);

            if (newRole is null)
            {
                throw new ArgumentNullException("Role dosen't exist");
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
                throw new ArgumentNullException("Role dosen't exist");
            }

            diaryDbContext.Remove(roleToDeletet);
            await diaryDbContext.SaveChangesAsync();
        }
    }
}
