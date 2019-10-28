using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.Services
{
    public class ProductService
    {

        public IRestResponse GetProduct(string url, Method method)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(method);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
