using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_MadHutchings.Models;

// what makes the database structured... shows all the required values,
// the ranges of possible numerical values, and length of word/characters
public class MovieEntry
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public string Title { get; set; } // required

    [Required]
    [Range(1888, 2024)]
    public int Year { get; set; } // required

    public string? Director { get; set; }

    public string? Rating { get; set; }
    
    [Required]
    public bool Edited { get; set; } // required
    
    [StringLength(25, ErrorMessage = "The LentTo field cannot exceed 25 characters.")]
    public string? LentTo { get; set; }

    [Required]
    public bool CopiedToPlex { get; set; } // required

    [StringLength(25, ErrorMessage = "The Notes field cannot exceed 25 characters.")]
    public string? Notes { get; set; }

}
