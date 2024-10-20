namespace Swim.Shared.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("vwEventChart")]
public class Event
{
    [Key]
    public int EventID { get; set; }
    public int AthleteID { get; set; }
    public string? Name { get; set; }
    public DateOnly EventDate { get; set; }
    public string? LcsTypeID { get; set; }
    public int EventSequence { get; set; }
    public TimeOnly? FinishTime { get; set; }
    public string? StateCutCss { get; set; }
    public string? MotivationCut { get; set; }
    public string? VideoPath { get; set; }
}
