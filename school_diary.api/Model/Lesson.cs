namespace school_diary.api.Model
{
    public class Lesson
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
