using ETicket.Data.Cart;
using ETicket.Interfaces;
using ETicket.Models;
using ETicket.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;

namespace ETicket.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IBaseRepository<Movie> _Movierepoistory;
        //private readonly IBaseRepository<Movie> _Movierepoistory;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IBaseRepository<Movie> moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _Movierepoistory = moviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            ViewBag.ElItems = items;
            var response = new ShoppingCartModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _Movierepoistory.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _Movierepoistory.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        [HttpGet]
        public IActionResult CompleteOrder()
        {
            return PartialView("_CompleteOrderPartialView");
        }

        [HttpPost]
        public async Task<IActionResult> CompleteOrder(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
           
            //string CustomerName = "Abanoub Ibrahim Marzouk";
            //string PhoneNumber = "01030662019";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress , order.CustomerName , order.PhoneNumber);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
