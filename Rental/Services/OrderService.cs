using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rental.DataBContext;
using Rental.Models;

namespace Rental.Services
{
    public class OrderService : IOrderService
    {
        private readonly RentalDbContext _context;

        public OrderService(RentalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Order
                .Include(o => o.User) // Подгрузка связанных данных
                .Include(o => o.Tool)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.User)
                .Include(o => o.Tool)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            var existingOrder = await _context.Order.FindAsync(id);
            if (existingOrder != null)
            {
                existingOrder.UserId = order.UserId;
                existingOrder.ToolId = order.ToolId;
                existingOrder.StartDate = order.StartDate;
                existingOrder.EndDate = order.EndDate;
                existingOrder.TotalPrice = order.TotalPrice;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}