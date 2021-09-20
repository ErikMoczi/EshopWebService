namespace EshopWebService.Application.Handlers.Features.Product.Queries.GetAllPaged
{
    public class GetAllProductsPagedResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}