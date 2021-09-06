using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhonebookAPI.Data;
using PhonebookAPI.Models;
using PhonebookAPI.Models.Dtos;

namespace PhonebookAPI.Services
{
    public class PhonebookServices : IPhonebookService
    {
        private readonly PhonebookContext _context;

        public PhonebookServices(PhonebookContext context) => 
            _context = context;

        public async Task CreateNewPersonAsync(Person personToCreate)
        {
            if(personToCreate == null)
                throw new ArgumentNullException(nameof(personToCreate));
            _context.People.Add(personToCreate);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> ReturnAllPeople() => 
            await _context.People.Include(p => p.Phones).ToListAsync();

        public Task<Person> ReturnPersonById(int id) => 
            _context.People.Include(p => p.Phones).FirstOrDefaultAsync(x => x.Id == id);
    }
}