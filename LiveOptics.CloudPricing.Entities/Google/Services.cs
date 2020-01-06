using System.Collections.Generic;

namespace LiveOptics.CloudPricing.Entities.Google
{
    public class Services
    {
        public string Name { get; set; }
        public string ServiceId { get; set; }
        public string DisplayName { get; set; }
    }

    public class ServicesResponse
    {
        public List<Services> Services { get; set; }
    }
}