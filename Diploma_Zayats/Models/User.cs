using Diploma_Zayats.Models.Enums;

namespace Diploma_Zayats.Models;

public class User
{
    public UserType UserType { get; set; }
    public string? Token { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}