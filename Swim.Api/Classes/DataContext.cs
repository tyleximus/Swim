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
    public DbSet<ProgressTime> ProgressTimes { get; set; }

    public Athlete? GetAthlete(string athleteID)
    {
        var result = (from a in Athletes select a)
            .Where(a => a.AthleteID == athleteID)
            .AsNoTracking()
            .ToList();
        if (result.Count() > 0)
        {
            return result.First();
        }
        else
        {
            return null;
        }
    }

    public IEnumerable<Athlete> GetAthletes(string nameFirst = "", string nameLast = "")
    {
        var sqlRaw = $@"SELECT * FROM Athlete
            WHERE ('{nameFirst}' = '' OR NameFirst = '{nameFirst}' OR NameFirstPreferred = '{nameFirst}')
            AND ('{nameLast}' = '' OR NameLast = '{nameLast}')";
        var result = Athletes.FromSqlRaw(sqlRaw);
        return result;
    }

    public IEnumerable<ProgressTime> GetProgressTimes()
    {
        var sqlRaw = $@"SELECT * FROM vwProgressChart ORDER BY OrderBy";
        var result = ProgressTimes.FromSqlRaw(sqlRaw);
        return result;
    }
}
