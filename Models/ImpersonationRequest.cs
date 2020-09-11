using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Skrawl.Models
{
    public class ImpersonationRequest
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
