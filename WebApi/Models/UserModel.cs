using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class UserModel
    {
        public string Login { get; set; }
        public string Md5Password { get; set; }
        public UserModel(string login, string md5Password)
        {
            Login = login;
            Md5Password = md5Password;
        }
    }
}
