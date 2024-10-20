namespace Swim.Shared.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Keyless]
[Table("vwProgressTime")]
public class ProgressTime
{
    public int Length { get; set; }
    public string? Stroke { get; set; }
    public string? Course { get; set; }
    public string? LcsTypeID { get; set; }
    public int Age { get; set; }
    public string? PR { get; set; }
    public string? PRClass { get; set; }
    public string? NagmtB { get; set; }
    public string? NagmtBClass { get; set; }
    public string? NagmtBB { get; set; }
    public string? NagmtBBClass { get; set; }
    public string? StateCut { get; set; }
    public string? StateCutClass { get; set; }
    public string? NagmtA { get; set; }
    public string? NagmtAClass { get; set; }
    public string? AgeGroupCut { get; set; }
    public string? AgeGroupCutClass { get; set; }
    public string? NagmtAA { get; set; }
    public string? NagmtAAClass { get; set; }
    public string? NagmtAAA { get; set; }
    public string? NagmtAAAClass { get; set; }
    public string? NagmtAAAA { get; set; }
    public string? NagmtAAAAClass { get; set; }
    public int OrderBy { get; set; }
}
