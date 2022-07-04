using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class UserRole
    {
        [Column("UserRoleId")]
        [Key]
        public int Id { get; set; }
        
        public int FK_RoleId { get; set; }
        [ForeignKey("FK_RoleId")]
        public virtual Role Role { get; set; }

        public Guid? FK_UserId { get; set; }
        
        [InverseProperty("Roles")]
        public User? User { get; set; }
    }
}
