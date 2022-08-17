using ConsumingApis.ApiClients;
using ConsumingApis.Models;
using System;

namespace ConsumingApis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Pairwork!");
            Console.WriteLine();

            // This API example provided as a demo of how to work
            StarWarsSample();

            // This method is what will have your own API additions
            CallAdditionalApis();
        }

        private static void StarWarsSample()
        {
            // See https://swapi.dev/ for documentation on the Star Wars API
            Console.WriteLine("This example uses the Star Wars API to get a person:");
            Console.WriteLine();

            StarWarsCharacterApiClient starWarsApi = new StarWarsCharacterApiClient();
            const int characterId = 4;
            StarWarsCharacter person = starWarsApi.GetCharacter(characterId);

            if (person == null)
            {
                Console.WriteLine("Could not find SW character " + characterId);
            }
            else
            {
                Console.WriteLine("Got SW Character " + characterId);
                Console.WriteLine($"{person.Name} has {person.Eye_color} eyes, {person.Hair_color} hair, and {person.Skin_color} skin.");
            }
        }


        private static void CallAdditionalApis()
        {
            // Create an instance of your API Client here
            RonSwansonQuotesAPIClient RonSwansonAPI = new RonSwansonQuotesAPIClient();

            // Call to your API client's method(s) of interest and display the results to the user
           string result =  RonSwansonAPI.GetRonQuote();
            Console.WriteLine(result);
        }
    }
}
