﻿namespace Psysup.DataAccess.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<Role>? Roles { get; set; }
    public IEnumerable<Application>? Applications { get; set; }
}