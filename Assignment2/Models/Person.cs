using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;

namespace Assignment2.Models
{
    public class Person
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }
        [Required]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }
        [Required]
        [JsonPropertyName("EyeColor")]
        public string EyeColor { get; set; }
        [Required]
        [JsonPropertyName("HairColor")]
        public string HairColor { get; set; }
        [Required]
        [JsonPropertyName("Age")]
        [Range(0, 125, ErrorMessage = "Age should be between {1} and {2}")]
        public int Age { get; set; }
        [Required]
        [JsonPropertyName("Weight")]
        [Range(1, 250, ErrorMessage = "Weight should be between {1} and {2}")]
        public float Weight { get; set; }
        [Required]
        [JsonPropertyName("Height")]
        [Range(30, 250, ErrorMessage = "Height should be between {1} and {2}")]
        public int Height { get; set; }
        [Required]
        [JsonPropertyName("Sex")]
        public string Sex { get; set; }

        public void Update(Person toUpdate)
        {
            Age = toUpdate.Age;
            Height = toUpdate.Height;
            HairColor = toUpdate.HairColor;
            Sex = toUpdate.Sex;
            Weight = toUpdate.Weight;
            EyeColor = toUpdate.EyeColor;
            FirstName = toUpdate.FirstName;
            LastName = toUpdate.LastName;
        }

    }

    public class ValidHairColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"blond", "red", "brown", "black",
            "white", "grey", "blue", "green", "leverpostej"}.ToList();
            if (valid == null || valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid hair colors are: Blond, Red, Brown, Black, White, Grey, Blue, Green, Leverpostej");
        }
    }

    public class ValidEyeColor : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> valid = new[] {"brown", "grey", "green", "blue",
            "amber", "hazel"}.ToList();
            if (valid != null && valid.Contains(value.ToString().ToLower()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Valid eye colors are: Brown, Grey, Green, Blue, Amber, Hazel");
        }
    }

}