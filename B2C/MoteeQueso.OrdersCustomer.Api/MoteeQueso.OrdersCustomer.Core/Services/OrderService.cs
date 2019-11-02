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
using System.Transactions;

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
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    using (B2CEntities entities = new B2CEntities())
                    {
                        order = new Orders
                        {
                            ordid = Guid.NewGuid(),
                            custid = customer.custid,
                            orderdate = DateTime.Now,
                            price = orderBo.Price,
                            status = "Create",
                            comments = orderBo.Comments
                        };

                        entities.orders.Add(order);

                        entities.SaveChanges();

                        foreach (ItemsBO itemBO in orderBo.Items)
                        {
                            ProductBO product = GetProductById(itemBO.ProdId);
                            Items item = new Items
                            {
                                itemid = Guid.NewGuid(),
                                partnum = "",
                                price = itemBO.Price,
                                prodid = product.ID,
                                productname = product.ESPECTACULO,
                                quantity = itemBO.Quantity,
                                ordid = order.ordid
                            };

                            entities.items.Add(item);

                        }
                        entities.SaveChanges();
                    }
                    scope.Complete();
                }
            }

            return order;
        }

        public Orders GetOrderById(Guid ordId)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.orders.Where(x => x.ordid == ordId).FirstOrDefault();
            }
        }

        private ProductBO GetProductById(int id)
        {
            ProductService productService = new ProductService();
            IRestResponse response = productService.GetProduct($"http://apib2c/api/Product/{id}", Method.GET);
            ProductBO product = JsonConvert.DeserializeObject<ProductBO>(response.Content);
            return product;
        }

        private Customer GetCustomerById(string custId)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.customer.Where(x => x.custid.Equals(custId)).FirstOrDefault();
            }
        }
    }
}
