using System;

namespace EasyBar.Domain.Entity.Authentication
{
    public class TokenEntity
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
