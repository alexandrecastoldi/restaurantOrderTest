using RestaurantOrder.Domain.Entities;
using RestaurantOrder.Domain.Interfaces.Repositories;
using RestaurantOrder.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrder.Infra.Services
{
    public class OrderService : IServiceOrder
    {
        private readonly IRepositoryOrder _orderRepository;

        public OrderService(IRepositoryOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async void Delete(int id)
        {
            try
            {
                Order order = await _orderRepository.GetById(id);
                if (order != null)
                {
                    _orderRepository.Delete(order);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> CreateOrder(string orderInput)
        {
            try
            {
                Order order = new Order();
                order.Input = orderInput;
                order.Output = GenerateOutput(orderInput);

                _orderRepository.Add(order);

                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Order> Update(int id, Order order)
        {
            var model = await _orderRepository.GetById(id);
            if (model == null) return null;

            _orderRepository.Update(order);

            return order;
        }

        public async Task<IEnumerable<Order>> RecoverAllOrders() => await _orderRepository.GetAllOrders();

        public async Task<Order> RecoverById(int id) => await _orderRepository.GetById(id);

        private string GenerateOutput(string orderInput)
        {
            try
            {
                IList<string> orderArray = orderInput.Split(",").ToList();
                string[] morningDishes = { "morning", "eggs", "toast", "coffee", "error" };
                string[] nightDishes = { "night", "steak", "potato", "wine", "cake" };
                string[] dishes;
                StringBuilder output = new StringBuilder();

                switch (orderArray[0])
                {
                    case "morning":
                        dishes = morningDishes;
                        break;
                    case "night":
                        dishes = nightDishes;
                        break;
                    default:
                        return "error";
                }
                orderArray.RemoveAt(0);
                orderArray = orderArray.OrderBy(x => x).ToList();
                int countItem = 1;
                int index = 0;

                for (int i = 0; i < orderArray.Count; i++)
                {
                    index = Int32.Parse(orderArray[i]);

                    if (index > 4)
                    {
                        output.Append(", error");
                        i = orderArray.Count;
                    }
                    else
                    {

                        if (i > 0 && orderArray[i] == orderArray[i - 1])
                        {
                            countItem++;
                        }
                        else
                        {
                            if (countItem == 1)
                                output.Append($", {dishes[index]}");
                            else
                            {
                                if (dishes[i - 1] == "coffee" || dishes[i - 1] == "potato")
                                    output.Append($"(x{countItem.ToString()}), {dishes[index]}");
                                else
                                {
                                    output.Append(", error");
                                    i = orderArray.Count;
                                }
                            }
                            countItem = 1;
                        }
                    }
                }

                if (countItem > 1)
                    output.Append($"(x{countItem.ToString()})");

                output.Remove(0, 2);
                return output.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
