using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2.Models
{
    public class Pet
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("Species")]
        public string Species { get; set; }
        [Required]
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("Age")]
        [Range(0, 60, ErrorMessage = "Age should be between {1} and {2}")]
        public int Age { get; set; }
    }
}