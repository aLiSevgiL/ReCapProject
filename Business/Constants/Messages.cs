using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInValid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarDeleted = "Araba kaydı silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarImagesAdded = "Araba Resmi eklendi";
        public static string CarImagesUpdate = "Araba Resmi Guncellendi";
        public static string CarImagesDelete = "Araba Resmi Silindi";
        public static string CarImageLimit = "Araba Resimleri 5 tane den fazla olamaz";
        public static string UserNotFound = "Kullanici Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfullLogin ="Giriş Başarılı";
        public static string UserAlReadyExits = "Kullanıcı mevcut";
        public static string UserRegistered = "Kullanici Kayit Oldu";
        public static string AccessTokenCreated="Access Token Başarıyla oluşturuldu";
    }
}
