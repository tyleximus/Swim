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

    [HttpGet("progress-times")]
    public IActionResult GetProgressTimes()
    {
        var result = _dataContext.GetProgressTimes();
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
