using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class Approve
    {
        [Key]
        [JsonIgnore]
        [Column("approveID")]
        public int Id { get; set; }
        [Required]
        public bool Positive { get; set; }
        public string Description { get; set; }

        public int FK_LessonId { get; set; }
        [JsonIgnore]
        [ForeignKey("FK_LessonId")]
        public virtual Lesson? Lesson { get; set; }
    }
}
