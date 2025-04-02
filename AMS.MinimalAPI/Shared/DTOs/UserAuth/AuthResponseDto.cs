namespace AMS.MinimalAPI.Shared.DTOs.UserAuth
{
    public class AuthResponseDto
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthResponseDto(string email, string token)
        {
            Email = email;
            Token = token;
        }
    }
}
