using System.ComponentModel.DataAnnotations;

namespace DutchTreatAspNetCore.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="Слишком длинное сообщение"),]
        public string Message { get; set; }

    }
}
