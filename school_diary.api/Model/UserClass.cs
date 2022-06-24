namespace school_diary.api.Model
{
    public class UserClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,8)]
        public int userClass { get; set; }
        [Required]
        [MaxLength(10)]
        public string userClassProfile { get; set; }
    }
}
