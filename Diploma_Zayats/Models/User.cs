using Diploma_Zayats.Models.Enums;

namespace Diploma_Zayats.Models;

public record User
{
    public UserType UserType { get; set; }
    public string? Token { get; init; } = string.Empty;
    public string? Username { get; init; } = string.Empty;
    public string? Password { get; init; } = string.Empty;
}