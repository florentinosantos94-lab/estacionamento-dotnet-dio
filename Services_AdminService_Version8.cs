using MinimalApiVeiculos.Models;

namespace MinimalApiVeiculos.Services
{
    public class AdminService
    {
        private static List<Admin> _admins = new()
        {
            new Admin { Username = "admin", Password = "123456" }
        };

        public bool Validate(string username, string password)
        {
            return _admins.Any(a => a.Username == username && a.Password == password);
        }
    }
}