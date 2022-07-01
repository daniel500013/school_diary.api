using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class Marks
    {
        [Key]
        [JsonIgnore]
        [Column("marksID")]
        public int Id { get; set; }
        [Required]
        public bool Present { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public int FK_LessonId { get; set; }
        
        [JsonIgnore]
        [ForeignKey("FK_LessonId")]
        public virtual Lesson? Lesson { get; set; }
    }
}
