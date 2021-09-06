using System;
using PhonebookAPI.Models.Enums;

namespace PhonebookAPI.Models
{
    public class PhoneNumber
    {
        public Guid Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
        public Person Person { get; set; }
    }
}