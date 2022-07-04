using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class Role
    {
        [Key]
        [JsonIgnore]
        [Column("roleID")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}