namespace school_diary.api.Model
{
    public class Role
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}