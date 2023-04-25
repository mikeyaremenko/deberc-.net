using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Card : Entity
{
    [MaxLength(16)]
    public string Name { get; set; } = string.Empty;
    public int Suit { get; set; }
    public int Weight { get; set; }
    public int OrderNumber { get; set; }
    public Player? Owner { get; set; }
}
