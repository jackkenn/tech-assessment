using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Repos
{
    public class OrderRepo
    {
        private static Dictionary<Guid, Models.OrderModel> orderDAL = new Dictionary<Guid, Models.OrderModel>();
        private static Dictionary<Guid, Models.CustomerModel> customerDAL = new Dictionary<Guid, Models.CustomerModel>();

        public OrderRepo()
        {
            add(new Models.CustomerModel("jack", new Guid("bf72a24e-0efe-4894-bb41-98575ee0102c"), new List<Models.OrderModel>() { new Models.OrderModel("Lambo, Apple") }));
            add(new Models.CustomerModel("Caroline", new List<Models.OrderModel>() { new Models.OrderModel("Porsche, Banana"), new Models.OrderModel("Corvette, Strawberry") }));
        }

        public void add(Models.CustomerModel c)
        {
            customerDAL.TryAdd(c.id, c);
            c.orders.ForEach(x => add(x));
        }

        public void add(Models.OrderModel o)
        {
            if(customerDAL.TryGetValue(o.customerId, out var c))
            {
                c.addOrder(o);
            }

            orderDAL.TryAdd(o.id, o);
        }

        public bool remove(Guid id)
        {
            if (orderDAL.TryGetValue(id, out var o) && (o?.active ?? false))
            {
                o.active = false;
                if(customerDAL.TryGetValue(o.customerId, out var c))
                {
                    c.orders.RemoveAll(x => x.id == o.id);
                }

                return true;
            }
            return false;
        }

        public bool update(Models.OrderModel orderModel)
        {
            if (orderDAL.TryGetValue(orderModel.id, out var o) && (o?.active?? false))
            {
                o.contents = orderModel.contents;
                return true;
            }

            return false;
        }

        public List<Models.CustomerModel> GetCustomersOrders()
        {
            return customerDAL.Select(x => x.Value).ToList();
        } 
    }
}
