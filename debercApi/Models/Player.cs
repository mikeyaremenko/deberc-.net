using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Player : Entity
{
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(64)]
    public string Password { get; set; } = string.Empty;
    public byte[]? Image { get; set; } 
    public int Index { get; set; }
}
