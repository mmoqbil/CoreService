namespace CoreService_backend.Models.Result
{
    public class AuthResult
    {

        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public string Token { get; set; }

        public AuthResult(bool result, string token)
        {
            Success = result;
            Token = token;
        }

        public AuthResult(bool result, string[] errors)
        {
            Errors = errors;
            Success = result;
        }
    }
}
