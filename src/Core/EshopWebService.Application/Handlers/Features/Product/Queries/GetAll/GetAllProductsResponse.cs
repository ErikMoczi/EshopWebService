namespace EshopWebService.Application.Handlers.Features.Product.Queries.GetAll
{
    public class GetAllProductsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUri { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}