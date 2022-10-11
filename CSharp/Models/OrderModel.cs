using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp.Models
{
    public class OrderModel
    {
        public string contents { get; set; }
        public Guid id { get; set; }
        public Guid customerId { get; set; }
        public bool active { get; set; }

        public OrderModel(string? contents, Guid id, Guid customerId)
        {
            this.contents = contents ?? "";
            this.id = id;
            this.customerId = customerId;
            this.active = true;
        }

        public OrderModel(string? contents, Guid customerId)
        {
            this.contents = contents?? "";
            this.id = Guid.NewGuid();
            this.customerId = customerId;
            this.active = true;
        }

        public OrderModel(string? contents)
        {
            this.contents = contents ?? "";
            this.id = Guid.NewGuid();
            this.active = true;
        }

        public OrderModel()
        {
            this.id = Guid.NewGuid();
            this.active = true;
        }
    }
}
