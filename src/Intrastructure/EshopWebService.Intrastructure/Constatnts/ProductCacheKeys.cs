namespace EshopWebService.Intrastructure.Constatnts
{
    public static class ProductCacheKeys
    {
        public static string GetAllKey => "AllProduct";
        public static string GetByIdKey(int productId) => $"Product-{productId}";
    }
}