using Azure.Core.Pipeline;

namespace CoreService_backend.Models.Response;

public class AuthResponse
{
}

public class AuthSuccessResponse
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
}

public class AuthFailedResponse
{
    public string[] Error { get; set; }
}