using System.Net.Http.Json;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public event Action ProductsChanged;

        public ProductService(HttpClient http)
        {
            this._http = http;
        }
        public List<Product> Products { get; set; } = new List<Product>();



        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/products/{productId}");
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null
                ? await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/products")
                : await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/products/category/{categoryUrl}");
            if (result != null && result.Data != null) Products = result.Data;

            ProductsChanged.Invoke();
        }
    }
}
