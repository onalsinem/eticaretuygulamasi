using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        public Task<List<ResultProductDetailDto>> ResultProductDetailAsync();

        public Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);

        public Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);

        public Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        public Task DeleteProductDetailAsync(string id);
    }
}
