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
            var result = _personService.GetPerson();
            if (!String.IsNullOrEmpty(result.Error))
                return NotFound(result.Error);

            return Ok(result.PersonModelList);

        }
        [HttpGet("GetPersonById")]
        public IActionResult GetPersons(int id)
        {
            var result = _personService.GetPersonById(id);
            if (!String.IsNullOrEmpty(result.Error))
                return NotFound(result.Error);

            return Ok(result.PersonModelList);

        }
        [HttpPost("InsertPerson")]
        public IActionResult InsertPerson([FromBody] PersonWrapper personModel)
        {
            var result = _personService.InsertPersonToTable(personModel);
            if (string.IsNullOrEmpty(result.Error))
                return Ok(result.Success);

            return NotFound(result.Error);
        }
        [HttpPut("UpdatePerson")]
        public IActionResult UpdatePerson([FromBody] PersonModel personModel)
        {
            var result = _personService.UpdatePersonToTable(personModel);

            if (string.IsNullOrEmpty(result.Error))
                return Ok(result.Success);

            return NotFound(result.Error);

        }
        [HttpDelete("DeletePersonById")]
        public IActionResult UpdatePerson(int id)
        {
            var result = _personService.DeletePersonById(id);
            if (string.IsNullOrEmpty(result.Error))
                return Ok(result.Success);


            return NotFound(result.Error);
        }
    }
}
