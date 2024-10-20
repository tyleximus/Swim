namespace Swim.App.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Swim.Shared.Models;

public interface ISwimService
{
  Task<Athlete> GetAthlete(int athleteID);
  Task<IEnumerable<Event>> GetEvents(int athleteID);
  Task<IEnumerable<ProgressTime>> GetProgressTimes(int athleteID);
}

public class SwimService : ISwimService
{
  private IHttpService _httpService;

  public SwimService(IHttpService httpService)
  {
    _httpService = httpService;
  }

  public async Task<Athlete> GetAthlete(int athleteID)
  {
    return await _httpService.Get<Athlete>($"athletes/{athleteID}");
  }

  public async Task<IEnumerable<Event>> GetEvents(int athleteID)
  {
    return await _httpService.Get<IEnumerable<Event>>($"events/{athleteID}");
  }

  public async Task<IEnumerable<ProgressTime>> GetProgressTimes(int athleteID)
  {
    return await _httpService.Get<IEnumerable<ProgressTime>>($"progress-times/{athleteID}");
  }
}
