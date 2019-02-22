using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
            get {
                double p = 0;
                for (int i = 0; i < flowers.Count; i++)
                    //sum up the entire cost
                    p += flowers[i].Cost;
                //does mark-up to grand total amount
                p *= 1.2;
                return p;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int n)
        {
            throw new NotImplementedException();
        }

        public void Deliver()
        {
            IClient c = this.Client;
            //what are you supposed to do if there is no class that actually uses the IOrderDAO interface...
            IOrderDAO dao = null;
            
            IOrder d = dao.GetOrder(this.Id);
            dao.SetDelivered(d);
        }
    }
}