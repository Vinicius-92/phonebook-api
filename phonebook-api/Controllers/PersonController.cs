using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhonebookAPI.Data;
using PhonebookAPI.Models;
using PhonebookAPI.Models.Dtos;

namespace PhonebookAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class PersonController : ControllerBase
    {
        private readonly IPhonebookService _phonebookService;
        private readonly IMapper _mapper;

        public PersonController(IPhonebookService phonebookService, IMapper mapper)
        {
            _phonebookService = phonebookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonReturnWithNumbers>>> ReturnAll()
        {
            var listOfPeopleRegistered = await _phonebookService.ReturnAllPeople();
            return Ok(_mapper.Map<List<PersonReturnWithNumbers>>(listOfPeopleRegistered));
        }

        [HttpGet("{id}", Name = "ReturnPersonById")]
        public async Task<ActionResult<PersonReturnWithNumbers>> ReturnPersonById(int id)
        {
            var personReturned = await _phonebookService.ReturnPersonById(id);
            return Ok(_mapper.Map<PersonReturnWithNumbers>(personReturned));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            var personModelToCreate = _mapper.Map<Person>(personDto);
            await _phonebookService.CreateNewPersonAsync(personModelToCreate);
            var personCreatedResponse = _mapper.Map<PersonCreatedResponse>(personModelToCreate);
            return CreatedAtRoute(nameof(ReturnPersonById), new { Id = personCreatedResponse.Id }, personCreatedResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(int id)
        {
            await _phonebookService.DeleteById(id);
            return NoContent();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddPhonenumberToPerson(CreatePhonenumberDto phoneNumberDto, int id)
        {
            var phoneNumberToAdd = _mapper.Map<PhoneNumber>(phoneNumberDto);
            await _phonebookService.AddPhonenumberToPerson(phoneNumberToAdd, id);
            return Ok();
        }
    }
}

