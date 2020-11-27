using System.Collections.Generic;
using System.Linq;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<UserModel> userList = new List<UserModel>()
        {
            new UserModel("TomPru","77f869401de682f60e0e749493ab793d"),
            new UserModel("Tomasz","5ebe2294ecd0e0f08eab7690d2a6ee69")
        };

        public bool IsUserExists(string login, string md5Password)
        {
            var user = userList.SingleOrDefault(x => x.Login.Equals(login) && x.Md5Password.ToUpper().Equals(md5Password));
            return user != null;
        }
    }
}
