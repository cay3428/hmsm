using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SalesUpdate = "Satış güncellendi";
        public static string SalesDelete = "Satış silindi";
        public static string SalesAdd = "Satış verisi depolandı";
        public static string CustomerAdd = "Müşteri Eklendi";
        public static string CustomerShows = "Müşteriler Görüntülendi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserShows = "Kullanıcılar Görüntülendi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime ="Sistem bakımda";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductsListed ="Ürünler listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="Yetkiniz yok.";
    }
}
