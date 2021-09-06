using System.ComponentModel.DataAnnotations;
using PhonebookAPI.Models.Enums;

namespace PhonebookAPI.Models.Dtos
{
    public class CreatePhonenumberDto
    {
        [Required]
        public PhoneType PhoneType { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(14)]
        public string Number { get; set; }
        public int PersonId { get; set; }
    }
}