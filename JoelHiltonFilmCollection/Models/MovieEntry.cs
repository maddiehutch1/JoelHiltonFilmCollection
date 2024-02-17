using System.ComponentModel.DataAnnotations;

namespace Mission06_MadHutchings.Models;

// what makes the database structured... shows all the required values, the ranges of possible numerical values, and length of word/characters
public class MovieEntry
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1888, 2024)]
    public int Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required] 
    public bool OneDirector { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool? Edited { get; set; }
    public string? LentTo { get; set; }
    [StringLength(25, ErrorMessage = "The Notes field cannot exceed 25 characters.")]
    public string? Notes { get; set; }

}
