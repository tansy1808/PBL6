using BookStore.API.Data;
using BookStore.API.Data.Enities.Auth;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO.Cart;
using BookStore.API.DTO.Product;
using BookStore.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Services
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly ICartReponsitory _cartReponsitory;

        public CartService(DataContext context, ICartReponsitory cartReponsitory)
        {
            _context = context;
            _cartReponsitory = cartReponsitory;
        }

        public Carts AddCart(CartDTO cartDTO)
        {
            var user = _context.Users.FirstOrDefault(c=>c.IdUser == cartDTO.IdUser);
            var cart = new Carts();
            if (user != null)
            {
                cart.IdUser = cartDTO.IdUser;
                _cartReponsitory.InsertCart(cart);
                _cartReponsitory.IsSaveChanges();
            }            
            return cart;
        }

        public CartItem AddCartItem(AddItemDTO addItemDTO)
        {
            var id = _context.Products.FirstOrDefault(c => c.IdProduct == addItemDTO.IdProduct);
            var cartItem = new CartItem();
            if (id != null) {
                var user = _context.Carts.FirstOrDefault(c => c.IdUser == addItemDTO.IdUser);
                if (user != null)
                {
                    cartItem.IdProduct = addItemDTO.IdProduct;
                    cartItem.IdCart = user.Id;
                    cartItem.Quantity = addItemDTO.Quantity;
                    _cartReponsitory.InsertCartItem(cartItem);
                    _cartReponsitory.IsSaveChanges();
                }
            }
            return cartItem;
        }

        public CartItem UpdateCartItem(int id, CartItemView cartItemView)
        {
            var item = _cartReponsitory.GetCartItemId(id);
            var cartitem = new CartItem();
            if (item != null)
            {
                cartitem.Quantity = cartItemView.quantity;
                _cartReponsitory.UpdateCartItem(cartitem);
                _cartReponsitory.IsSaveChanges();
            }
            return cartitem;
        }

        public Carts DeleteCart(int id)
        {
            var cart = _cartReponsitory.GetCarts(id);
            if (cart != null)
            {
                var item = _cartReponsitory.getCartItem(cart.Id);
                if (item != null)
                {
                    foreach (CartItem i in item)
                    {
                        _cartReponsitory.DeleteItem(i);
                    }
                }                
                _cartReponsitory.IsSaveChanges();
            } 
            return cart;
        }

        public CartItem DeleteItem(int id)
        {
            var cartitem = _cartReponsitory.GetCartItemId(id);
            if (cartitem != null) 
            {
                _cartReponsitory.DeleteItem(cartitem);
                _cartReponsitory.IsSaveChanges();
                return cartitem;
            }
            return cartitem;
        }

        public CartView GetCartId(int id)
        {
            var view = new CartView();
            var cart = _cartReponsitory.GetCarts(id);
            if (cart != null)
            {
                var item = _cartReponsitory.getCartItem(cart.Id);
                var list = new List<CartItemDTO>();
                if (item != null)
                {
                    foreach (CartItem i in item)
                    {
                        var pro = _context.Products.FirstOrDefault(c => c.IdProduct == i.IdProduct);
                        var produ = new ProductView 
                        {
                            IdProduct = pro.IdProduct,
                            Name = pro.Name,
                            Image = pro.Image,
                            Desc = pro.Desc,
                            Feedback = pro.Feedback,
                            Price = pro.Price,
                            Quantity = pro.Quantity,
                            DateCreate = pro.DateCreate,
                            Discount = pro.Discount,
                            Cate = _context.Categories.FirstOrDefault(c => c.Id == pro.IdCate).CategoryType
                        };
                        var tem = new CartItemDTO
                        {
                            id= i.Id,
                            QuantityCart=i.Quantity,
                            Product = produ
                            
                        };
                        list.Add(tem);
                    }
                }
                view.Id = cart.Id;
                view.items = list;
            }
            return view;
        }
    }
}