namespace AuthenticationService.DTOs
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; } // seconds
    }

    public class ValidateResponse
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}