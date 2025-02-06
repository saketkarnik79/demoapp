using MVCClient.Models;

namespace MVCClient.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync($"/products");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            return products;
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"/products/{id}");
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<Product>();
            return product;
        }
    }
}
