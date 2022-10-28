using RestWithASPNETUdemy.Data.VO;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly PostgreSQLContext _context;

        public UserRepositoryImplementation(PostgreSQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO userVO)
        {
            var pass = ComputeHash(userVO.Password, SHA256.Create());

            return _context.Users.FirstOrDefault(u => (u.UserName == userVO.UserName) && (u.Password == pass));
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.FirstOrDefault(u => (u.UserName == userName));
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.FirstOrDefault(u => (u.UserName == userName));
            if (user == null)
                return false;

            user.RefreshToken = "";
            _context.SaveChanges();

            return true;
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(p => p.Id.Equals(user.Id)))
                return null;

            var result = _context.Users.SingleOrDefault(i => i.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private string ComputeHash(string input, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
