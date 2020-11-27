using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AccessToken
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
