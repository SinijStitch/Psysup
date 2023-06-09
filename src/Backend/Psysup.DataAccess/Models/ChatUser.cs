﻿namespace Psysup.DataAccess.Models;

public class ChatUser
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }

    public User? User { get; set; }
    public Chat? Chat { get; set; }
}