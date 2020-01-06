using LiveOptics.CloudPricing.Entities.Google;
using Newtonsoft.Json;
using RestSharp;

namespace LiveOptics.CloudPricing.Service.Pricing
{
    public class AWS
    {
        //const string offerIndexFile = "https://pricing.us-east-1.amazonaws.com/offers/v1.0/aws/index.json";
        //const string fullEc2File = "https://pricing.us-east-1.amazonaws.com/offers/v1.0/aws/AmazonEC2/current/index.json"; //1.2GB
        private const string usEastEC2File = "https://pricing.us-east-1.amazonaws.com/offers/v1.0/aws/AmazonEC2/current/us-east-1/index.json"; //83Mb

        //Details: https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/using-ppslong.html#download-the-offer-index

        private const string dumpFilePrefix = "AWS";

        public void GatherInformation()
        {
            DownloadFile();
        }

        private ServicesResponse DownloadFile()
        {
            var client = new RestClient(usEastEC2File);
            IRestResponse json = client.Execute(new RestRequest(Method.GET));
            Utility.DumpToFile(dumpFilePrefix, json.Content);

            return JsonConvert.DeserializeObject<ServicesResponse>(json.Content);
        }
    }
}