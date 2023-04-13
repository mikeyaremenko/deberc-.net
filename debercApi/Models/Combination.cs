using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Combination
{
    [Key]
    public int Id { get; set; }
    public CombinationType Type { get; set; }
    public Team? OwnerTeam { get; set; }
    public int Score { get; set; }
    public Round? GameRound { get; set; }
}
