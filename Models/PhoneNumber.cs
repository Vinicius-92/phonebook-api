using System;
using System.Text.Json.Serialization;
using PhonebookAPI.Models.Enums;

namespace PhonebookAPI.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Number { get; set; }
        [JsonIgnore]
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}