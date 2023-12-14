namespace Swim.App.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Swim.Shared.Models;

public interface ISwimService
{
    Task<Athlete> GetAthlete(string athleteID);
    Task<IEnumerable<ProgressTime>> GetProgressTimes(string athleteID);
}

public class SwimService : ISwimService
{
    private IHttpService _httpService;

    public SwimService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<IEnumerable<ProgressTime>> GetProgressTimes(string athleteID)
    {
        return await _httpService.Get<IEnumerable<ProgressTime>>($"progress-times/");
    }
    public async Task<Athlete> GetAthlete(string athleteID)
    {
        return await _httpService.Get<Athlete>($"athletes/{athleteID}");
    }
}