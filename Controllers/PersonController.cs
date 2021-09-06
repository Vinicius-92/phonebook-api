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
        public async Task<ActionResult<IEnumerable<PersonCreatedResponse>>> ReturnAll()
        {
            var listOfPeopleRegistered = await _phonebookService.ReturnAllPeople();
            return Ok(_mapper.Map<List<PersonCreatedResponse>>(listOfPeopleRegistered));
        }

        [HttpGet("{id}", Name = "ReturnPersonById")]
        public async Task<ActionResult<PersonCreatedResponse>> ReturnPersonById(int id)
        {
            var personReturned = await _phonebookService.ReturnPersonById(id);
            return Ok(_mapper.Map<PersonCreatedResponse>(personReturned));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            var personModelToCreate = _mapper.Map<Person>(personDto);
            await _phonebookService.CreateNewPersonAsync(personModelToCreate);
            var personCreatedResponse = _mapper.Map<PersonCreatedResponse>(personModelToCreate);
            return CreatedAtRoute(nameof(ReturnPersonById), new { Id = personCreatedResponse.Id }, personCreatedResponse);
        }
    }
}

