using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clinicaveterinariaBackEnd.Entities;
using clinicaveterinariaBackEnd.Extension;
using clinicaveterinariaBackEnd.Helps;
using clinicaveterinariaBackEnd.Interfaces;

namespace clinicaveterinariaBackEnd.Service
{
    public class ServicesUsuario : IUserService
    {
        private readonly DataContext _datacontext;
        public ServicesUsuario(DataContext dataContext)
        {
            _datacontext = dataContext;
        }
        public Usuario Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _datacontext.Usuarios
                        .SingleOrDefault(x => (
                                                x.EmailUsuario == username ||
                                                x.Username == username
                                            ));
            // check if username exists
            if (user == null)
                return null;
            // check if password is correct
            //  Usar este método cuando se actualice la forma de almacenar las contrasenias de texto plano a uso de hash
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            // authentication successful
            return user.WithoutPassword();
        }

        public Usuario Create(Usuario user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_datacontext.Usuarios.Any(x => x.Username == user.Username))
                throw new AppException("UserName '" + user.Username + "' is already taken");

            if (_datacontext.Usuarios.Any(x => x.EmailUsuario == user.EmailUsuario))
                throw new AppException("Email '" + user.EmailUsuario + "' is already taken");


            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            _datacontext.Usuarios.Add(user);
            _datacontext.SaveChanges();

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public Usuario UpdatePassword(Usuario user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
