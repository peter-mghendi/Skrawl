using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Skrawl.Models
{
    [Table("notes")]
    public class Note
    {
        [Column("id")]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Column("title")]
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [Column("body")]
        [JsonPropertyName("body")]
        public string Body { get; set; }

        [Column("user_id")]
        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}