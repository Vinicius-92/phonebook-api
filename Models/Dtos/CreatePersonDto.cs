using System;
using System.ComponentModel.DataAnnotations;

namespace PhonebookAPI.Models.Dtos
{
    public class CreatePersonDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(14)]
        public string CPF { get; set; }
        [Required]
        [DataType(DataType.Date)]   
        public DateTime BirthDate { get; set; }
    }
}