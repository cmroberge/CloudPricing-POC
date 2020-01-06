using LiveOptics.CloudPricing.Entities.Google;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Linq;
using System.Net;

namespace LiveOptics.CloudPricing.Service.Pricing
{
    public class Azure
    {
        private const string subscriptionId = "78c8beff-ab54-44a6-aa03-f1412ddc1a54";
        //private const string subscriptionIdProd = "b5f72763-9710-4b6b-82ed-02cd2d3ba1f7";
        string tenantId = "945c199a-83a2-4e80-9f8c-5a91be5752dd";
        
        private const string dumpFilePrefix = "Azure";

        //https://docs.microsoft.com/en-us/previous-versions/azure/reference/mt219004(v=azure.100)

        public void GatherInformation()
        {
            GetAllServices();
        }

        private ServicesResponse GetAllServices()
        {
            string token = getToken();
            string url = $"https://management.azure.com/subscriptions/{subscriptionId}/providers/Microsoft.Commerce/RateCard?api-version=2016-08-31-preview&$filter=OfferDurableId eq 'MS-AZR-0003p' and Currency eq 'USD' and Locale eq 'en-US' and RegionInfo eq 'US'";
            var client = new RestClient(url);
            client.AddDefaultHeader(HttpRequestHeader.Authorization.ToString(), "Bearer " + token);

            IRestResponse json = client.Execute(new RestRequest(Method.GET));
            Utility.DumpToFile(dumpFilePrefix, json.Content);

            return JsonConvert.DeserializeObject<ServicesResponse>(json.Content);
        }
        private string getToken()
        {
            string url = $"https://management.azure.com/subscriptions/{subscriptionId}/providers/Microsoft.Commerce/RateCard?api-version=2016-08-31-preview&$filter=OfferDurableId eq 'MS-AZR-0003p' and Currency eq 'USD' and Locale eq 'en-US' and RegionInfo eq 'US'";


            RestRequest request = new RestRequest();
            request.AddHeader("Accept", "application/json");
            request.AddParameter("grant_type", "client_credentials");
                      

            var client = new RestClient(url);
            
            //client.Authenticator = new HttpBasicAuthenticator("client-app", "secret");
            IRestResponse json = client.Execute(request);
            return JsonConvert.DeserializeObject<ServicesResponse>(json.Content);
        }

        //Steps
        //Az Login
        /*
        [
        {
        "cloudName": "AzureCloud",
        "id": "4d5aec20-0d07-4500-86b0-1db4d49b1235",
        "isDefault": true,
        "name": "AzD1N-OmsPilot-Sx01",
        "state": "Enabled",
        "tenantId": "945c199a-83a2-4e80-9f8c-5a91be5752dd",
        "user": {
        "name": "Carlos_Martins_Rodri@Dell.com",
        "type": "user"
        }
        },
        {
        "cloudName": "AzureCloud",
        "id": "b5f72763-9710-4b6b-82ed-02cd2d3ba1f7",
        "isDefault": false,
        "name": "AzD1P-DpackCaesar-Sx01",
        "state": "Enabled",
        "tenantId": "945c199a-83a2-4e80-9f8c-5a91be5752dd",
        "user": {
        "name": "Carlos_Martins_Rodri@Dell.com",
        "type": "user"
        }
        },
        {
        "cloudName": "AzureCloud",
        "id": "78c8beff-ab54-44a6-aa03-f1412ddc1a54",
        "isDefault": false,
        "name": "AzD1N-DpackLiveOptics-Sx01",
        "state": "Enabled",
        "tenantId": "945c199a-83a2-4e80-9f8c-5a91be5752dd",
        "user": {
        "name": "Carlos_Martins_Rodri@Dell.com",
        "type": "user"
        }
        }
        ]*/


    }
}
