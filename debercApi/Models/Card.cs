using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Card
{
    [Key]
    public int Id { get; set; }
    [MaxLength(16)]
    public string Name { get; set; } = string.Empty;
    public int Suit { get; set; }
    public int Weight { get; set; }
    public int OrderNumber { get; set; }
    public Player? Owner { get; set; }
}
