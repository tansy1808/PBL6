using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.Services.IServices;

namespace BookStore.API.Services.Services
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;

        public CartService(DataContext context)
        {
            _context = context;
        }
        public void DeleteCart(Carts carts)
        {
            _context.Carts.Remove(carts);
        }

        public void DeleteItem(CartItem cartitem)
        {
            _context.CartItems.Remove(cartitem);
        }

        public List<CartItem> getCartItem(int id)
        {
            return _context.CartItems.Where(c => c.IdCart == id).ToList();
        }

        public CartItem GetCartItemId(int id) => _context.CartItems.FirstOrDefault(c => c.Id == id);

        public Carts GetCartsId(int id) => _context.Carts.FirstOrDefault(c => c.IdUser == id);

        public void InsertCart(Carts carts)
        {
            _context.Carts.Add(carts);
        }

        public void InsertCartItem(CartItem cartitem)
        {
            _context.CartItems.Add(cartitem);
        }

        public bool IsSaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void UpdateCart(Carts carts)
        {
            _context.Carts.Update(carts);
        }
    }
}