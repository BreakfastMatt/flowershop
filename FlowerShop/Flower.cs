using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Flower : IFlower
    {
        public string Description { get; private set; }

        public double Cost { get;  set; }

        public int Id { get; }

        public int Stock { get; private set; }

        public Flower(IFlowerDAO dao, string desc, double cost, int stock)
        {
            Description = desc;
            Cost = cost;
            Stock = stock;
            Id = dao.AddFlower(desc, cost, stock);
        }
    }
}
