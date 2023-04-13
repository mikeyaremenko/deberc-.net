﻿using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Player
{
    [Key]
    public int Id { get; set; }
    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(64)]
    public string Password { get; set; } = string.Empty;
    public int Index { get; set; }
}
