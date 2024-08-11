namespace GameStore.Frontend;

public class GenerationClient
{
    private readonly Generation[] generations =[
        new(){
            Id = 1,
            Name = "Fighter",
        },
        new(){
            Id = 2,
            Name = "Roleplaying",
        },
        new(){
            Id = 3,
            Name = "Sports",
        },
        new(){
            Id = 4,
            Name ="Racing",
        },
        new(){
            Id = 5,
            Name = "Kids and Family",
        }
    ];
    public Generation[] GetGenerations => generations;
}
