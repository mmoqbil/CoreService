namespace CoreService_backend.Models.Result;

public class AuthResult
{
    public string? Token { get; set; }
    public bool Result { get; set; }
    public List<string>? Errors { get; set; }
    private string? userId { get; set; }

    public AuthResult(bool result, List<string> errors)
    {
        Result = result;
        Errors = errors;
    }

    public AuthResult(bool result, string token)
    {
        Token = token;
        Result = result;
    }
}