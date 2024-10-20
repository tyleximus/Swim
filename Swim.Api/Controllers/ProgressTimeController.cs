namespace Swim.Api.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swim.Api.Classes;

[Route("/")]
[ApiController]
public class ProgressTimeController : ControllerBase
{
  private readonly DataContext _dataContext;

  public ProgressTimeController(DataContext dataContext)
  {
    _dataContext = dataContext;
  }

  [HttpGet("progress-times/{athleteID}")]
  public async Task<IActionResult> GetProgressTimes(int athleteID)
  {
    try
    {
      return Ok(await _dataContext.GetProgressTimes(athleteID));
    }
    catch(Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }
}
