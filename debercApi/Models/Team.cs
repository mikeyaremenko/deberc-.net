﻿using System.ComponentModel.DataAnnotations;

namespace debercApi.Models;

public class Team : Entity
{
    [MaxLength(32)]
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; }
    public Player? FirstPlayer { get; set; }
    public Player? SecondPlayer { get; set; }
}
