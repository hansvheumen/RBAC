namespace HobbyRazorCLient.Models
{
    public class PrincipalDTO
    {
        public PrincipalDTO(string name, string email, string? password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
        public PrincipalDTO() : this("", "", "") { }



        public string Name { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

    }
}