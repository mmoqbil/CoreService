using CoreService_backend.Models.Entities;

namespace CoreService_backend.Models.Result;

public class AuthenticationResult
{
    public bool Success { get; set; }
    public string Token { get; set; }
    public RefreshToken RefreshToken { get; set; }
    public string[] Errors { get; set; }
}