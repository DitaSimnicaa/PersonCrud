using Microsoft.AspNetCore.Mvc;
using PersonCrud.Model;
using PersonCrud.Services;

namespace PersonCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly PersonService _personService;

        public HomeController(PersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("GetAllPersons")]
        public IActionResult GetPersons()
        {
            var person = _personService.GetPerson();
            if (person.Count == 0)
                return NotFound("No persons registred! Please register one");

            return Ok(person);

        }
        [HttpGet("GetPersonById")]
        public IActionResult GetPersons(int id)
        {
            var person = _personService.GetPersonById(id);
            if (person == null)
                return NotFound("Person not found!");

            return Ok(person);

        }
        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson([FromBody] PersonWrapper personModel)
        {
            bool person = _personService.InsertPersonToTable(personModel);
            if (!person)
                return NotFound("Something failed");

            return Ok("Person inserted successfully!");
            

        }
        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] PersonModel personModel)
        {
            var person = _personService.UpdatePersonToTable(personModel);

            if (!person)
                return NotFound("No person found with that Id");

            return Ok("Person updated successfully!");

        }
        [HttpDelete("DeletePersonById")]
        public IActionResult UpdatePerson(int id)
        {
            bool person = _personService.DeletePersonById(id);
            if (!person)
            {
                return NotFound("No person found with that Id");
            }
            else
            {
                return Ok("Person deleted successfully!");
            }
        }
    }
}
