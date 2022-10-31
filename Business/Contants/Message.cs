using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public static class Message
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Error = "Hata Meydana Geldi";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SuccessfulLogin = "Sisteme Giriş İşlemi Başaralı";
        public static string UserAlreadyExists= "Bu Kullanıcı Zaten Mevcut";
        public static string UserRegistered="Kullanıcı Başarıyla Eklendi";
        public static string AccessTokenCreated="Access Token Oluşturuldu";

        public static string ErrorAccessToken = "Acces Token İşlemi Hatalı";
    }
}
