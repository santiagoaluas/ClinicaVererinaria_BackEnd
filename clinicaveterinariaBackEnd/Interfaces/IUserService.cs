using clinicaveterinariaBackEnd.Entities;

namespace clinicaveterinariaBackEnd.Interfaces
{
    public interface IUserService
    {
        Usuario Authenticate(string username, string password);
        Usuario Create(Usuario user, string password);
        Usuario UpdatePassword(Usuario user, string password);
    }
}
