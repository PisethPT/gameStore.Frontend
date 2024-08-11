namespace GameStore.Frontend;

public class GameSummery
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Generation { get; set; }
    public decimal Prices { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
 