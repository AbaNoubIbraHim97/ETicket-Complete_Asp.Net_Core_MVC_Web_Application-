using ETicket.Data;
using ETicket.Interfaces;
using ETicket.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicket.Repositories
{
    public class OrdersService : IOrdersService
    {
        protected readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.User).ToListAsync();

            if (userRole != "admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress, string CustomerName, string PhoneNumber)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
                CustomerName = CustomerName,
                PhoneNumber = PhoneNumber
                
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price,
                    //CinemaId = item.Cinema.Id,
                    //PartyId = item.Parties.Id,
                    //Date = item.Date
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
