using BookStore.API.Data.Enities.Cart;

namespace BookStore.API.DATA.Reponsitories
{
    public interface ICartReponsitory
    {
        void InsertCart(Carts carts);
        void InsertCartItem(CartItem cartitem);
        void UpdateCart(Carts carts);
        void DeleteCart(Carts carts);
        void DeleteItem(CartItem cartitem);
        List<CartItem> getCartItem(int id);
        Carts GetCarts(int id);
        CartItem GetCartItemId(int id);
        bool IsSaveChanges();
    }
}
