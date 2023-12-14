namespace Swim.Api.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swim.Api.Classes;

[Route("/")]
[ApiController]
public class AthleteController : ControllerBase
{
    private readonly DataContext _dataContext;

    public AthleteController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("athletes/{athleteID}")]
    public IActionResult GetAthlete(string athleteID)
    {
        var result = _dataContext.GetAthlete(athleteID);
        if (result != null)
        {
            return Ok(result);
        }
        else
        {
            return NoContent();
        }
    }

    [HttpGet("athletes")]
    public IActionResult GetAthletes(string nameFirst = "", string nameLast = "")
    {
        var result = _dataContext.GetAthletes(nameFirst, nameLast);
        if (result.Any())
        {
            return Ok(result);
        }
        else
        {
            return NoContent();
        }
    }
}
