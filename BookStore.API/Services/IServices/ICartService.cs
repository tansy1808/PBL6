using BookStore.API.Data.Enities.Cart;

namespace BookStore.API.Services.IServices
{
    public interface ICartService
    {
        void InsertCart(Carts carts);
        void InsertCartItem(CartItem cartitem);
        void UpdateCart(Carts carts);
        void DeleteCart(Carts carts);
        void DeleteItem(CartItem cartitem);
        List<CartItem> getCartItem(int id);
        Carts GetCartsId(int id);
        CartItem GetCartItemId(int id);
        bool IsSaveChanges();
    }
}