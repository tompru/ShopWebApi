using System;

namespace WebApiTestApp.Models
{
    public class AccessToken
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
