using Kustodya.WebApi.Models;

namespace WebApi.Models
{
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public long UserId { get; set; }
        public bool SuperAdmin { get; set; }
        public UsuarioModel Usuario { get; set; }

        public class Divipola
        {
            public string City { get; set; }
            public string Country { get; set; }

            public int Id { get; set; }
            public string Region { get; set; }
        }
    }
}