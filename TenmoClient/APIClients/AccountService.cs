using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using TenmoClient.Data;



namespace TenmoClient.APIClients
{
    public class AccountService
    {
        private const string API_BASE_URL = "https://localhost:44315/";
        private readonly IRestClient client = new RestClient();


        public API_User GetAccountBalance() // used to display login account balance
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Account/Balance");

            IRestResponse<API_User> response = client.Get<API_User>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.Data);
            }
            return response.Data;
        }

        public bool UpdateBalances(API_Transfer transfer) //used to update sender and receiver account
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Transfer/Account/");
            
            request.AddJsonBody(transfer); 

            IRestResponse response = client.Put(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return false;
            }
            if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.StatusDescription);
                return false;
            }
            return true;
        }

        public List<API_User> GetAllUsers() // use to collect list of users
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Account/AllAccounts");

            IRestResponse<List<API_User>> response = client.Get<List<API_User>>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.StatusDescription);
                return null;
            }
            return response.Data;
        }
        public API_User SelectUserById(int userId) 
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Account/User/" + userId);

            IRestResponse<API_User> response = client.Get<API_User>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.StatusDescription);
                return null;
            }
            return response.Data;


        }

        public API_Transfer StartTransfer(API_Transfer newTransfer) // used to create transfer
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Transfer/Create");

            request.AddJsonBody(newTransfer);

            IRestResponse<API_Transfer> response = client.Post<API_Transfer>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.StatusDescription);
                return null;
            }
            return response.Data;

        }
        public API_Account GetAccountIdByUserId(int userId) // used to get accountId by userId
        {
            RestRequest request = new RestRequest(API_BASE_URL + "Account/" + userId);

            IRestResponse<API_Account> response = client.Get<API_Account>(request);

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                Console.WriteLine("An error occurred communicating with the server.");
                return null;
            }
            else if (!response.IsSuccessful)
            {
                Console.WriteLine("An error message was received: " + response.StatusDescription);
                return null;
            }
            return response.Data;
        }
         
    
               
        public bool HasAuthToken
        {
            get
            {
                return token != null;
            }
        }

        private string token;

        public void UpdateToken(string jwt)
        {
            token = jwt;

            // Any request with this client in the future will AUTOMATICALLY
            // contain the Authorization / Bearer token header
            if (jwt == null)
            {
                client.Authenticator = null;
            }
            else
            {
                client.Authenticator = new JwtAuthenticator(jwt);
            }
        }

    }
}
