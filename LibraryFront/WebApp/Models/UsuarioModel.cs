using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Dto;

namespace WebApp.Models
{
    public class UsuarioModel
    {
        public class LoginUsuarioRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string TokenType { get; set; }
            public string AccessToken { get; set; }
            public string ExpiresIn { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}
