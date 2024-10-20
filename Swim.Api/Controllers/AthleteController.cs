namespace Swim.Api.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swim.Api.Classes;
using Swim.Shared.Models;
using System.Transactions;

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
  public async Task<ActionResult<Athlete>> GetAthlete(int athleteID)
  {
    try
    {
      var result = await _dataContext.GetAthlete(athleteID);
      if (result == null)
      {
        return NotFound();
      }
      return result;
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }

  [HttpGet("athletes")]
  public async Task<ActionResult> GetAthletes(string firstName = "", string lastName = "")
  {
    try
    {
      return Ok(await _dataContext.GetAthletes());
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }

  [HttpGet("events/{athleteID}")]
  public async Task<ActionResult> GetEvents(int athleteID)
  {
    try
    {
      return Ok(await _dataContext.GetEvents(athleteID));
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }
}
