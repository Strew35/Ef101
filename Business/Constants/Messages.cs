namespace Business.Constants
{
    public static class Messages
    {
        /* Maintance */
        public static string MaintanceTime = "Sistem bakım aşamasında.";

        /* Product */
        /* Validations */
        public static string ProductNameInvalid = "Ürün adı geçersiz.";
        /* CRUD's */
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductCouldNotBeAdded = "Ürün eklenemedi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductCouldNotBeUpdated = "Ürün güncellenemedi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductCouldNotBeDeleted = "Ürün silinemedi.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductsCouldNotBeListed = "Ürünler listelenemedi.";
        public static string ProductListed = "Ürün listelendi.";
        public static string ProductCouldNotBeListed = "Ürün listelenemedi.";
        /* Business Controls */
        public static string ProductCountOfCategoryError = "İlgili kategoride belirlenen ürün limitine erişildi.";
        public static string ProductNameDuplicationError = "Aynı isimde birden fazla ürün olamaz.";

        /* Category */
        public static string CategoriesListed = "Kategoriler listelendi.";
        public static string CategoryListed = "Kategori listelendi.";
        /* Business Controls */
        public static string CategoryLimitExceed = "Kategori için verilen sınır aşıldı.";
    }
}
