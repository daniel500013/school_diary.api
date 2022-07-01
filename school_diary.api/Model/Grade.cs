using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class Grade
    {
        [Key]
        [JsonIgnore]
        [Column("gradeID")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int FK_LessonId { get; set; }
        
        [JsonIgnore]
        [ForeignKey("FK_LessonId")]
        public virtual Lesson? Lesson { get; set; }
    }
}
