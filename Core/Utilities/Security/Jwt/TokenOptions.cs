using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
   public class TokenOptions
    {
        public string Audience { get; set; } //token hedef kitlesi/alan kişi
        public string Issuer { get; set; } //token kim tarafından oluşturuldu ise imzası
        public string SecurityKey { get; set; } //token imzalayacak algoritma ve anahtar
        public int AccesTokenExpiration { get; set; }
    }
}
