using eShopping.Basket.Core.Entities.ShoppingCartAggregate;
using eShopping.Basket.Core.Repositories;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace eShopping.Basket.Infrastructure.Repositories
{
    public class BasketRepository(IConnectionMultiplexer muxer) : IBasketRepository
    {
        private readonly IDatabase _redis = muxer.GetDatabase();

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var value = await _redis.StringGetAsync(userName);
            if (string.IsNullOrEmpty(value)) return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(value);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await _redis.StringSetAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.UserName);
        }

        public async Task DeleteBasket(string userName)
        {
            await _redis.KeyDeleteAsync(userName);
        }
    }
}