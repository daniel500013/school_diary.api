using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class User
    {
        [Key]
        [JsonIgnore]
        [Column("userUUID")]
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

        [JsonIgnore]
        public int FK_userClassId { get; set; } = 1;
        [JsonIgnore]
        [ForeignKey("FK_userClassId")]
        public virtual UserClass? userClass { get; set; }

        [JsonIgnore]
        [ForeignKey("FK_UserId")]
        public virtual ICollection<UserRole>? Roles { get; set; }
    }
}
