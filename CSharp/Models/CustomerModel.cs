using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Models
{
    public class CustomerModel
    {
        public string name { get; set; }
        public Guid id { get; set; }
        public List<OrderModel> orders { get; set; }

        public CustomerModel(string name, List<OrderModel> orders)
        {
            this.orders = new List<OrderModel>();
            this.name = name;
            this.id = Guid.NewGuid();
            orders.ForEach(x => addOrder(x));
        }

        public CustomerModel(string name, Guid id, List<OrderModel> orders)
        {
            this.orders = new List<OrderModel>();
            this.name = name;
            this.id = id;
            orders.ForEach(x => addOrder(x));
        }

        public void addOrder(OrderModel o)
        {
            o.customerId = id;
            if(orders.Where(x => x.id == o.id).Count() < 1)
            {
                orders.Add(o);
            }
        }
    }
}
