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
    public string? AthleteID { get; set; }

    public string? NameFirst { get; set; }

    public string? NameFirstPreferred { get; set; }

    public string? NameLast { get; set; }

    [Column("GenderTypeID")]
    public GenderType Gender { get; set; }

    public DateOnly BirthDate { get; set; }

    [Column("LscTypeID")]
    public LscType? Lsc { get; set; }

    [Column("ClubTypeID")]
    public ClubType? Club { get; set; }

    public string? SwimCloudID { get; set; }
}

public enum GenderType
{
    Male = 1,
    Female
}

public enum LscType
{
    KY = 1
}

public enum ClubType
{
    LEXD = 1
}