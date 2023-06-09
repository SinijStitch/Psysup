﻿namespace Psysup.DataAccess.Models;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? ImagePath { get; set; }

    public IEnumerable<Role>? Roles { get; set; }
    public IEnumerable<Application>? Applications { get; set; }
    public IEnumerable<AppliedDoctorApplication>? DoctorApplications { get; set; }
    public IEnumerable<Chat>? Chats { get; set; }
}