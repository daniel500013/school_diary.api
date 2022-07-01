using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class Lesson
    {
        [Key]
        [JsonIgnore]
        [Column("lessonID")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid FK_UserUUID { get; set; }
        
        [JsonIgnore]
        [ForeignKey("FK_UserUUID")]
        public virtual User? User { get; set; }
    }
}
