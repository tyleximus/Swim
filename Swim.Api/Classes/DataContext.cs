namespace Swim.Api.Classes;

using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Swim.Shared.Models;
using System.Text;

public class DataContext : DbContext
{
  protected readonly IConfiguration _configuration;

  public DataContext(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("OnPrem"));
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }

  public DbSet<Athlete> Athletes { get; set; }
  public DbSet<Event> Events { get; set; }
  public DbSet<ProgressTime> ProgressTimes { get; set; }

  public async Task<Athlete> GetAthlete(int athleteID)
  {
    var result = await (from a in Athletes select a)
      .Where(a => a.AthleteID == athleteID)
      .AsNoTracking()
      .ToListAsync();
    return result.FirstOrDefault();
  }

  public async Task<IEnumerable<Athlete>> GetAthletes(string firstName = "", string lastName = "")
  {
    var sqlRaw = $@"SELECT * FROM Athlete
      WHERE ('{firstName}' = '' OR FirstName = '{firstName}' OR FirstNamePreferred = '{firstName}')
      AND ('{lastName}' = '' OR LastName = '{lastName}')";
    var result = await Athletes.FromSqlRaw(sqlRaw).ToListAsync();
    return result;
  }

  public async Task<IEnumerable<Event>> GetEvents(int athleteID)
  {
    var result = await (from e in Events select e)
      .Where(e => e.AthleteID == athleteID)
      .AsNoTracking()
      .ToListAsync();
    return result;
  }

  public async Task<IEnumerable<ProgressTime>> GetProgressTimes(int athleteID)
  {
    var sqlRaw = $@"SELECT * FROM fnProgressChart({athleteID}) ORDER BY OrderBy";
    var result = await ProgressTimes.FromSqlRaw(sqlRaw).ToListAsync();
    return result;
  }
}
