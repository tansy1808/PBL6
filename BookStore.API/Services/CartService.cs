using BookStore.API.Data;
using BookStore.API.Data.Enities.Cart;
using BookStore.API.DATA.Reponsitories;
using BookStore.API.DTO.Cart;
using BookStore.API.DTO.Product;

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

        public ViewCartDTO AddCart(CartDTO cartDTO)
        {
            var user = _context.Users.FirstOrDefault(c=>c.IdUser == cartDTO.IdUser);
            var cart = new Carts();
            var view = new ViewCartDTO()
            {
                Status= "Error",
                Message= "User không tồn tại.",
                data = null
            };
            if (user != null)
            {
                cart.IdUser = cartDTO.IdUser;
                _cartReponsitory.InsertCart(cart);
                _cartReponsitory.IsSaveChanges();
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = cart;
            }            
            return view;
        }

        public ViewCartItemDTO AddCartItem(AddItemDTO addItemDTO)
        {
            var id = _context.Products.FirstOrDefault(c => c.IdProduct == addItemDTO.IdProduct);
            var cartItem = new CartItem();
            var cart = new CartViewDTO();
            var view = new ViewCartItemDTO()
            {
                Status = "Error",
                Message = "Không có sản phẩm.",
                data = null
            };
            if (id != null) {
                var user = _context.Carts.FirstOrDefault(c => c.IdUser == addItemDTO.IdUser);
                var pro = _context.CartItems.Where(c=>c.IdCart == user.Id).FirstOrDefault(c=>c.IdProduct == addItemDTO.IdProduct);
                if(pro != null )
                {
                    var view1 = new ViewCartItemDTO
                    {
                        Status = "Error",
                        Message = "Sản phẩm đã có trong giỏ.",
                        data = null
                    };
                    return view1;
                }
                if (user != null)
                {
                    cartItem.IdProduct = addItemDTO.IdProduct;
                    cartItem.IdCart = user.Id;
                    cartItem.Quantity = addItemDTO.Quantity;
                    _cartReponsitory.InsertCartItem(cartItem);
                    _cartReponsitory.IsSaveChanges();
                    cart.Id = cartItem.Id;
                    cart.IdProduct = cartItem.IdProduct;
                    cart.IdCart = cartItem.IdCart;
                    cart.QuantityCart = cartItem.Quantity;
                    cart.product = _context.Products.FirstOrDefault(a=>a.IdProduct== cartItem.IdProduct);
                    view.Status = "Success";
                    view.Message = "Thành công";
                    view.data = cart;
                }
            }
            return view;
        }

        public ViewCartItemDTO UpdateCartItem(int id, CartItemView cartItemView)
        {
            var item = _cartReponsitory.GetCartItemId(id);
            var cart = new CartViewDTO();
            var view = new ViewCartItemDTO()
            {
                Status = "Error",
                Message = "Item không tồn tại.",
                data = null
            };
            if (item != null)
            {
                item.Quantity = cartItemView.quantity;
                _cartReponsitory.UpdateCartItem(item);
                _cartReponsitory.IsSaveChanges();
                cart.Id = item.Id;
                cart.IdProduct = item.IdProduct;
                cart.IdCart = item.IdCart;
                cart.QuantityCart = item.Quantity;
                cart.product = _context.Products.FirstOrDefault(a=>a.IdProduct== item.IdProduct);
                view.Status = "Success";
                view.Message = "Thành công";
                view.data = cart;
            }
            return view;
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