using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories
{
    public interface IUserRepository
    {
        public bool IsUserExists(string login, string md5Password);
    }
}
