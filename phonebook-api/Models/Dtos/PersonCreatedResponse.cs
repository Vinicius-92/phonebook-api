using System;

namespace PhonebookAPI.Models.Dtos
{
    public class PersonCreatedResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}