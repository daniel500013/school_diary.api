namespace school_diary.api.Model
{
    public class Marks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool Present { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        public int LessonID { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
