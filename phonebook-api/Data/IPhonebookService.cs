using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonebookAPI.Models;
using PhonebookAPI.Models.Dtos;

namespace PhonebookAPI.Data
{
    public interface IPhonebookService
    {
        Task CreateNewPersonAsync(Person personToCreate);
        Task<IEnumerable<Person>> ReturnAllPeople();
        Task<Person> ReturnPersonById(int id);
        Task DeleteById(int id);
        Task AddPhonenumberToPerson(PhoneNumber PhoneNumber, int id);
    }
}