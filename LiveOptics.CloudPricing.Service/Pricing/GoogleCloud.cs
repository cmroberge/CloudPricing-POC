using LiveOptics.CloudPricing.Entities.Google;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;

namespace LiveOptics.CloudPricing.Service.Pricing
{
    public class GoogleCloud
    {
        private const string apiKey = "AIzaSyBBLQVgan5001vldvOQOz4GkCjGW5rFuZc";
        private const string dumpFilePrefix = "GoogleService";
        //project: https://console.cloud.google.com/apis/credentials?project=lo-cp-263821
        //sku mapping: https://cloud.google.com/skus/legacy-ids
        //https://cloud.google.com/billing/v1/how-tos/catalog-api
        //Google Compute Engine == GCE
        //SKU: Compute Engine: 6F81-5844-456A
        //https://cloudbilling.googleapis.com/v1/services/6F81-5844-456A/skus/0003-6B5C-97EC

        public void GatherInformation()
        {
            var serviceResponse = GetAllServices();
            //foreach (var service in serviceResponse.Services)
            //{
            //    GoogleCloudPricing.GetSKUsPerService(service.ServiceId);
            //}
            var computeEngineService = serviceResponse.Services.SingleOrDefault(t => t.DisplayName.Equals("Compute Engine", StringComparison.CurrentCultureIgnoreCase));
            GetSKUsPerService(computeEngineService.ServiceId);
        }

        private ServicesResponse GetAllServices()
        {
            var url = $"https://cloudbilling.googleapis.com/v1/services?key={apiKey}";
            var client = new RestClient(url);
            IRestResponse json = client.Execute(new RestRequest(Method.GET));
            Utility.DumpToFile(dumpFilePrefix, json.Content);

            return JsonConvert.DeserializeObject<ServicesResponse>(json.Content);
        }

        private ServiceSkuResponse GetSKUsPerService(string serviceID)
        {
            var url = $"https://cloudbilling.googleapis.com/v1/services/{serviceID}/skus?key={apiKey}";
            var client = new RestClient(url);
            IRestResponse json = client.Execute(new RestRequest(Method.GET));
            Utility.DumpToFile($"{dumpFilePrefix}-{serviceID}", json.Content);

            return JsonConvert.DeserializeObject<ServiceSkuResponse>(json.Content);
        }
    }
}