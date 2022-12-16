using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO.Cart;
using BookStore.API.Services;

namespace BookStore.API.Services
{
    public class CartService : ICartService
    {
        private readonly ICartReponsitory _cartReponsitory;

        public CartService( ICartReponsitory cartReponsitory)
        {
            _cartReponsitory = cartReponsitory;
        }

        public Carts AddCart(CartDTO cartDTO)
        {
            var cart = new Carts
            {
                IdUser = cartDTO.IdUser
            };
            _cartReponsitory.InsertCart(cart);
            _cartReponsitory.IsSaveChanges();
            return cart;
        }

        public CartItem AddCartItem(CartItemDTO cartItemDTO)
        {
            var cartItem = new CartItem
            {
                IdProduct = cartItemDTO.IdProduct,
                IdCart = cartItemDTO.IdCart,
                Quantity = cartItemDTO.Quantity
            };
            _cartReponsitory.InsertCartItem(cartItem);
            _cartReponsitory.IsSaveChanges();
            return cartItem;
        }

        public Carts DeleteCart(int id)
        {
            var cart = _cartReponsitory.GetCarts(id);
            var item = _cartReponsitory.getCartItem(cart.Id);
            if (cart == null) throw new UnauthorizedAccessException("Không có sản phẩm");
            foreach (CartItem i in item)
            {
                _cartReponsitory.DeleteItem(i);
            }
            _cartReponsitory.DeleteCart(cart);
            _cartReponsitory.IsSaveChanges();
            return cart;
        }

        public CartItem DeleteItem(int id)
        {
            var cartitem = _cartReponsitory.GetCartItemId(id);
            if (cartitem != null) throw new UnauthorizedAccessException("Không có sản phẩm");
            _cartReponsitory.DeleteItem(cartitem);
            _cartReponsitory.IsSaveChanges();
            return cartitem;
        }

        public CartView GetCartId(int id)
        {
            var cart = _cartReponsitory.GetCarts(id);
            var item = _cartReponsitory.getCartItem(cart.Id);
            var list = new List<CartItemDTO>();
            foreach (CartItem i in item)
            {
                var tem = new CartItemDTO
                {
                    IdCart = i.IdCart,
                    IdProduct = i.IdProduct,
                    Quantity = i.Quantity
                };
                list.Add(tem);
            }
            var view = new CartView
            {
                Id = cart.Id,
                items = list
            };
            return view;
        }
    }
}