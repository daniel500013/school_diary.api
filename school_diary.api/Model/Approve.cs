namespace school_diary.api.Model
{
    public class Approve
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public bool Positive { get; set; }
        public string Description { get; set; }

        public int LessonId { get; set; }
        [JsonIgnore]
        public virtual Lesson? Lesson { get; set; }
    }
}
