namespace GameStore.Frontend;

public class GameClient
{
    private List<GameSummery> games =
        [
            new(){
            Id = 1,
            Name = "Street Fighter II",
            Generation = "Fighting",
            Prices = 19.99M,
            ReleaseDate = new DateOnly(1992,7,12)
        },
        new(){
            Id = 2,
            Name = "Final Fantasy XIV",
            Generation = "Roleplaying",
            Prices = 59.99M,
            ReleaseDate = new DateOnly(2010,9,9)
        },
        new(){
            Id = 3,
            Name = "FIFA 2023",
            Generation = "Sports",
            Prices = 69.99M,
            ReleaseDate = new DateOnly(2022,9,10)
        }
        ];
       // public GameSummery[] GetGames => games.ToArray(); // method 1
        public GameSummery[] GetGames => [..games]; // method 2 copy list into array
        private readonly Generation[] generations = new GenerationClient().GetGenerations;

    public GameSummery AddGame(GameDetail game)
    {
        // method 1:
        // ArgumentException.ThrowIfNullOrWhiteSpace(game.GenerationId);
        // var genre = generations.Single(g=>g.Id == int.Parse(game.GenerationId));

        // method 2:
        Generation genre = GetGenreById(game.GenerationId);
        var GameSummery = new GameSummery
        {
            Id = games.Count + 1,
            Name = game.Name,
            Generation = genre.Name,
            Prices = game.Prices,
            ReleaseDate = game.ReleaseDate
        };
        games.Add(GameSummery);
        return GameSummery;
    }

    private Generation GetGenreById(string? Id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Id);
       return generations.Single(g => g.Id == int.Parse(Id));
    }

    public GameDetail GetGameById(int Id)
    {
        // method 3:
        GameSummery game = GetGameSummeryById(Id);
        // var game = games.Find(game => game.Id == Id);
        // // method 2:
        // ArgumentNullException.ThrowIfNull(game);
        var genre = generations.Single(genre => string.Equals(genre.Name, game.Generation, StringComparison.OrdinalIgnoreCase));
        // method 1:
        // var genre = generations.Single(genre => string.Equals(genre.Name, game!.Name, StringComparison.OrdinalIgnoreCase));

        return new GameDetail
        {
            Id = Id,
            Name = game.Name,
            GenerationId = genre.Id.ToString(),
            Prices = game.Prices,
            ReleaseDate = game.ReleaseDate
        };
    }

    private GameSummery GetGameSummeryById(int Id)
    {
        var game = games.Find(game => game.Id == Id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    // update game
    public void UpdateGame(GameDetail updatedGame){
        var genre = GetGenreById(updatedGame.GenerationId);
        var exitingGame = GetGameSummeryById(updatedGame.Id);
        exitingGame.Name = updatedGame.Name;
        exitingGame.Generation = updatedGame.Name;
        exitingGame.Prices = updatedGame.Prices;
        exitingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    // delete game
    public void DeleteGame(int Id){
        var game = GetGameSummeryById(Id);
        games.Remove(game);
    }
}
