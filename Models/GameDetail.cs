using System.ComponentModel.DataAnnotations;

namespace GameStore.Frontend;

public class GameDetail
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required(ErrorMessage = "The Genre Field is required.")]
    public string? GenerationId { get; set; }
    [Range(1,100)]
    public decimal Prices { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
