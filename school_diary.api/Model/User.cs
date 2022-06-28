namespace school_diary.api.Model
{
    public class User
    {
        [Key]
        public Guid uuid { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string hashPassword { get; set; } = "";
        [MaxLength(9)]
        public string? phone { get; set; }
        public string? state { get; set; }
        public string? city { get; set; }
        [MaxLength(6)]
        public string? zipCode { get; set; }
        public string? address { get; set; }

        public int RoleId { get; set; } = 1;
        public virtual Role? Role { get; set; }

        public int userClassId { get; set; } = 1;
        public virtual UserClass? userClass { get; set; }
    }
}
