namespace Swim.Shared.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Explicitly defining table name is required; otherwise, EF Core pluralizes the entity name
/// </summary>
[Table("Athlete")]
public class Athlete
{
    [Key]
    public int AthleteID { get; set; }

    public string? FirstName { get; set; }

    public string? FirstNamePreferred { get; set; }

    public string? LastName { get; set; }

    public char Gender { get; set; }

    public int Age { get; set; }

    public DateOnly BirthDate { get; set; }

    [Column("ClubTypeID")]
    public ClubType? Club { get; set; }

    public string? UsaSwimmingID { get; set; }

    public string? SwimCloudID { get; set; }
}

public enum ClubType
{
    LEXD = 1
}