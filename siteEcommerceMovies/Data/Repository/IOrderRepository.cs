using siteEcommerceMovies.Models;

namespace siteEcommerceMovies.Data.Repository
{
    public interface IOrderRepository
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}