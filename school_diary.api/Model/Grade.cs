namespace school_diary.api.Model
{
    public class Grade
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int LessonId { get; set; }
        [JsonIgnore]
        public virtual Lesson? Lesson { get; set; }

        public int UserClassId { get; set; }
        [JsonIgnore]
        public virtual UserClass? UserClass { get; set; }
    }
}
