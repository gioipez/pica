using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace ReciveClients
{
    class ClienteRestSharp
    {
        public IRestResponse Request(string url, Method Envio, object ObjetoEnviar)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Envio);
            request.AddJsonBody(ObjetoEnviar);
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}
