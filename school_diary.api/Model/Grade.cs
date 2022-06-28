namespace school_diary.api.Model
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson? Lesson { get; set; }
    }
}
