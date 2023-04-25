namespace debercApi.Models;

public class Combination : Entity
{
    public CombinationType Type { get; set; }
    public Team? OwnerTeam { get; set; }
    public int Score { get; set; }
    public Round? GameRound { get; set; }
}
