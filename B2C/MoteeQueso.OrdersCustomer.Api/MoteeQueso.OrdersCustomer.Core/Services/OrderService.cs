using MoteeQueso.OrdersCustomer.Core.Interfaces;
using MoteeQueso.OrdersCustomer.Core.ModelsBO;
using MoteeQueso.OrdersCustomer.Infraestructure.Data;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.Services
{
    public class OrderService : IOrdersService
    {
        public Orders Create(OrderBO orderBo)
        {
            Customer customer = GetCustomerById(orderBo.CustId);
            Orders order = null;

            if (customer != null)
            {
                using (B2CEntities entities = new B2CEntities())
                {

                    order = new Orders
                    {
                        OrdId = Guid.NewGuid(),
                        CustId = customer.CustId,
                        OrderDate = DateTime.Now,
                        Price = orderBo.Price,
                        Status = "Create",
                        Comments = orderBo.Comments
                    };

                    entities.Orders.Add(order);

                    entities.SaveChanges();

                    foreach (ItemsBO itemBO in orderBo.Items)
                    {
                        ProductBO product = GetProductById(itemBO.ProdId);
                        Items item = new Items
                        {
                            ItemId = Guid.NewGuid(),
                            PartNum = "",
                            Price = itemBO.Price,
                            ProdId = product.ID,
                            ProductName = product.ESPECTACULO,
                            Quantity = itemBO.Quantity,
                            OrdId = order.OrdId
                        };

                        entities.Items.Add(item);

                        
                    }
                    entities.SaveChanges();
                }
            }

            return order;
        }

        public Orders GetOrderById(Guid ordId)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.Orders.Where(x => x.OrdId == ordId).FirstOrDefault();
            }
        }

        private ProductBO GetProductById(int id)
        {
            ProductService productService = new ProductService();
            IRestResponse response = productService.GetProduct($"http://localhost/api/Product/{id}", Method.GET);
            ProductBO product = JsonConvert.DeserializeObject<ProductBO>(response.Content);
            return product;
        }

        private Customer GetCustomerById(string custId)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.Customer.Where(x => x.CustId.Equals(custId)).FirstOrDefault();
            }
        }
    }
}
