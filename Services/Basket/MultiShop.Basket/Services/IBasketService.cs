using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task SaveBasket(BasketTotalDto basketTotalDto);

        Task<BasketTotalDto> GetBasket(string userId);

        Task DeleteBasket(string userId);
    }
}
