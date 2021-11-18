using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Get a list of all people registered
        /// </summary>
        /// <returns>List of people registered and their lista oh phones</returns>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<PersonReturnWithNumbers>>> ReturnAll()
        {
            var listOfPeopleRegistered = await _phonebookService.ReturnAllPeople();
            if (listOfPeopleRegistered == null) return NoContent();
            return Ok(_mapper.Map<List<PersonReturnWithNumbers>>(listOfPeopleRegistered));
        }

        /// <summary>
        /// Get a person's record by id
        /// </summary>
        /// <param name="id">Person's id</param>
        /// <returns>Person and it's list of phones</returns>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}", Name = "ReturnPersonById")]
        public async Task<ActionResult<PersonReturnWithNumbers>> ReturnPersonById(int id)
        {
            var personReturned = await _phonebookService.ReturnPersonById(id);
            return personReturned == null ? NotFound() : Ok(_mapper.Map<PersonReturnWithNumbers>(personReturned));
        }

        /// <summary>
        /// Create a person's record in database
        /// </summary>
        /// <param name="personDto">Person's data in json format</param>
        /// <returns></returns>
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDto personDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var personModelToCreate = _mapper.Map<Person>(personDto);
            await _phonebookService.CreateNewPersonAsync(personModelToCreate);
            var personCreatedResponse = _mapper.Map<PersonCreatedResponse>(personModelToCreate);
            return CreatedAtRoute(nameof(ReturnPersonById), new { Id = personCreatedResponse.Id }, personCreatedResponse);
        }

        /// <summary>
        /// Delete a person's record by id
        /// </summary>
        /// <param name="id">Person's id</param>
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonById(int id)
        {
            var personToDelete = await _phonebookService.ReturnPersonById(id);
            if(personToDelete != null)
            {
                await _phonebookService.DeleteById(id);
                return NoContent();
            }
            return NotFound();
        }

        /// <summary>
        /// Add phone number to person's record
        /// </summary>
        /// <remarks>
        /// Types of phone:
        /// 
        /// 0 - Home
        /// 
        /// 1 - Cellphone
        /// 
        /// 2 - Commercial
        /// </remarks>
        /// <param name="id">Person's id</param>
        /// <param name="phoneNumberDto">Person's phone number to add</param>
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{id}")]
        public async Task<IActionResult> AddPhonenumberToPerson(CreatePhonenumberDto phoneNumberDto, int id)
        {
            if(!ModelState.IsValid) return BadRequest();
            var personToAddPhoneNumber = await _phonebookService.ReturnPersonById(id);
            if(personToAddPhoneNumber == null) return NotFound();
            var phoneNumberToAdd = _mapper.Map<PhoneNumber>(phoneNumberDto);
            await _phonebookService.AddPhonenumberToPerson(phoneNumberToAdd, id);
            return NoContent();
        }
    }
}

