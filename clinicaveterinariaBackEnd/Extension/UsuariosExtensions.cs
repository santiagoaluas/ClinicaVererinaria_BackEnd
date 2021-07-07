using clinicaveterinariaBackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinicaveterinariaBackEnd.Extension
{
    public static class UsuariosExtensions
    {
        public static IEnumerable<Usuario> WithoutPasswords(this IEnumerable<Usuario> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static Usuario WithoutPassword(this Usuario user)
        {
            user.PasswordHash = null;
            user.PasswordSalt = null;
            return user;
        }
    }
}
