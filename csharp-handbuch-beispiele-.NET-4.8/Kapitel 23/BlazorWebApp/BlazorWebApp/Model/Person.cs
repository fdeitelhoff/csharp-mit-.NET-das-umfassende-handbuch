using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.Model
{
    public class Person
    {
        [Required(ErrorMessage = "Der Name ist erforderlich.")]
        public string Name { get; set; } = "";

        [Range(20, 130, ErrorMessage = "Bitte gib ein Alter zwischen 20 und 130 an.")]
        public int Alter { get; set; }
    }
}
