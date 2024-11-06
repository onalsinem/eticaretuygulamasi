using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        public Task<List<ResultProductDto>> ResultProductAsync();

        public Task<GetByIdProductDto> GetGetByIdProductAsync(string id);

        public Task UpdateProductAsync(UpdateProductDto updateProductDto);

        public Task CreateProductAsync(CreateProductDto createProductDto);

        public Task DeleteProductAsync(string id);
    }
}
