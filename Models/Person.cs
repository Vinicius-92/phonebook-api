using System;
using System.Collections.Generic;

namespace PhonebookAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public List<PhoneNumber> Phones { get; set; }
    }
}