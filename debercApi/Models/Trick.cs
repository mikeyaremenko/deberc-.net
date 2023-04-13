using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Trick
{
    [Key]
    public int Id { get; set; }
    public Team? WinnerTeam { get; set; }
    public Player? StarterPlayer { get; set; }
    public int Score { get; set; }
    public Round? OwnerRound { get; set; }
    public List<Card> Cards { get; set; } = new List<Card>();
}
