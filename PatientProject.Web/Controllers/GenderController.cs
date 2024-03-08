using Microsoft.AspNetCore.Mvc;
using PatientProject.Core.DTOs.Gender;
using PatientProject.Core.Interfaces.Services;
using System.ComponentModel.DataAnnotations;

namespace PatientProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private IGenderService _genderService;

        public GenderController(IGenderService genderService) => _genderService = genderService;

        [HttpGet("all")]
        public ActionResult All([FromQuery] bool isActive = false) =>
            Ok(_genderService.List(isActive));

        [HttpPost]
        public ActionResult Create([Required][FromBody] string name)
        {
            if (_genderService.IsExists(name))
                return Conflict("Genter busy!");

            _genderService.Create(name);
            return Ok();
        }

        [HttpPut]
        public ActionResult Edit([Required][FromBody] GenderUpdateRequest model)
        {
            if (!_genderService.IsExists(model.Id))
                return NotFound("Genter not found!");

            _genderService.Update(model);
            return Ok();
        }

        [HttpPut("togglestate")]
        public ActionResult ToggleState([Required][FromQuery] Guid id)
        {
            if (!_genderService.IsExists(id))
                return NotFound("Gender not found!");

            _genderService.ToggleState(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            if (!_genderService.IsExists(id))
                return NotFound("Gender not found!");

            _genderService.Delete(id);
            return Ok();
        }
    }
}
