using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace ConsumingApis.ApiClients
{
    public class RonSwansonQuotesAPIClient
    {
        private RestClient client;

        public RonSwansonQuotesAPIClient()
        {
            this.client = new RestClient("http://ron-swanson-quotes.herokuapp.com/v2/quotes/");
        }

        public string GetRonQuote()
        {
            RestRequest request = new RestRequest();

            IRestResponse<string> response = client.Get<string>(request);

            if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return response.Data;
        }

    }
}
