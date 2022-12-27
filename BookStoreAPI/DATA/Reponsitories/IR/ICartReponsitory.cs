using BookStoreAPI.DATA.Enities.Cart;

namespace BookStoreAPI.DATA.Reponsitories.IR
{
    public interface ICartReponsitory
    {
        void InsertCart(Carts carts);
        void InsertCartItem(CartItem cartitem);
        void UpdateCart(Carts carts);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCart(Carts carts);
        void DeleteItem(CartItem cartitem);
        List<CartItem> getCartItem(int id);
        Carts GetCarts(int id);
        CartItem GetCartItemId(int id);
        bool IsSaveChanges();
    }
}
