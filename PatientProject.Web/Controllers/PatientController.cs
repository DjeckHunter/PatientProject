using Microsoft.AspNetCore.Mvc;
using PatientProject.Core.DTOs.Patient;
using PatientProject.Core.Interfaces.Services;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PatientProject.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;
    private IGenderService _genderService;

    public PatientController(IPatientService patientService, IGenderService genderService)
    {
        _patientService = patientService;
        _genderService = genderService;
    }

    [HttpGet]
    public ActionResult Get([Required][FromQuery] Guid id) =>
        Ok(_patientService.GetById(id));

    [HttpGet("all")]
    public ActionResult All([FromQuery] bool isActive = false, [FromQuery] List<string>? parametrs = null)
    {
        Regex regex = new Regex(@"^(eq|ne|lt|gt|ge|le|sa|eb|ap)\d{4}-\d{2}-\d{2}(T\d{2}:\d{2})?$");
        foreach (var item in parametrs)
        {
            MatchCollection matches = regex.Matches(item);
            if (matches.Count < 1)
                return BadRequest("Wrong parametr");
        }

        return Ok(_patientService.List(isActive, parametrs));
    }

    [HttpPost]
    public ActionResult Create([Required][FromBody] PatientCreateRequestDTO model)
    {
        if (!_genderService.IsExists(model.GenderId))
            return NotFound("Genter not found!");

        _patientService.Create(model);
        return Ok();
    }

    [HttpPut]
    public ActionResult Edit([Required][FromBody] PatientUpdateRequestDTO model)
    {
        if (!_genderService.IsExists(model.GenderId) || !_patientService.IsExists(model.Id))
            return NotFound("Genter or patient not found!");

        _patientService.Update(model);
        return Ok();
    }

    [HttpPut("togglestate")]
    public ActionResult ToggleState([Required][FromQuery] Guid id)
    {
        if (!_patientService.IsExists(id))
            return NotFound("Patient not found!");

        _patientService.ToggleState(id);
        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete(Guid id)
    {
        if (!_patientService.IsExists(id))
            return NotFound("Patient not found!");

        _patientService.Delete(id);
        return Ok();
    }
}