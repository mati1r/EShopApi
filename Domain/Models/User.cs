﻿using Core.Models.EShop;

namespace Core.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public string? Salt { get; set; }

    public string[] Roles { get; set; } = [];

    public int? AddressId { get; set; } = null;

    public ICollection<Tokens> Tokens { get; set; } = [];
    public ICollection<History> Histories { get; set; } = [];
}
