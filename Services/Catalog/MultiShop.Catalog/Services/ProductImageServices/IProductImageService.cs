using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        public Task<List<ResultProductImageDto>> ResultProductImageAsync();

        public Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);

        public Task DeleteProductImageAsync(string id);

        public Task<GetByIdProductImageDto> GetByIdProductImageAsync(String id);

        public Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    }
}
