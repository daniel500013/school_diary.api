using System.ComponentModel.DataAnnotations.Schema;

namespace school_diary.api.Model
{
    public class UserClass
    {
        [Key]
        [JsonIgnore]
        [Column("userclassID")]
        public int Id { get; set; }
        [Required]
        [Range(1, 8)]
        public int userClass { get; set; }
        [MaxLength(10)]
        public string userClassProfile { get; set; }
    }
}
