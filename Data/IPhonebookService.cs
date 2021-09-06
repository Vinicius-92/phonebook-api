using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhonebookAPI.Models;

namespace PhonebookAPI.Data
{
    public interface IPhonebookService
    {
        Task CreateNewPersonAsync(Person personToCreate);
        Task<IEnumerable<Person>> ReturnAllPeople();
        Task<Person> ReturnPersonById(int id);
    }
}