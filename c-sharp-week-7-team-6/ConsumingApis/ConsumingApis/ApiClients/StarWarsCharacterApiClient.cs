using ConsumingApis.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumingApis.ApiClients
{
    public class StarWarsCharacterApiClient
    {
        private RestClient client;

        public StarWarsCharacterApiClient()
        {
            this.client = new RestClient("https://swapi.dev/api/");
        }

        public StarWarsCharacter GetCharacter(int id)
        {
            RestRequest request = new RestRequest($"people/{id}");

            IRestResponse<StarWarsCharacter> response = client.Get<StarWarsCharacter>(request);

            if (!response.IsSuccessful || response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return response.Data;
        }
    }
}
