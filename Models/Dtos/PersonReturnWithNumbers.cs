using System.Collections.Generic;

namespace PhonebookAPI.Models.Dtos
{
    public class PersonReturnWithNumbers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<PhoneNumber> Phones { get; set; }
    }
}