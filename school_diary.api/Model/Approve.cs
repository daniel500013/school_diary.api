namespace school_diary.api.Model
{
    public class Approve
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Positive { get; set; }
        public string Description { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}
