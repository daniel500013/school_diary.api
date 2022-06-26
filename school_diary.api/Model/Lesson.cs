namespace school_diary.api.Model
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
