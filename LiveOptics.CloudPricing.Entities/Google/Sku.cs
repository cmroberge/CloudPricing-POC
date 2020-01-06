using System.Collections.Generic;

namespace LiveOptics.CloudPricing.Entities.Google
{
    public class Category
    {
        public string serviceDisplayName { get; set; }
        public string resourceFamily { get; set; }
        public string resourceGroup { get; set; }
        public string usageType { get; set; }
    }

    public class UnitPrice
    {
        public string currencyCode { get; set; }
        public string units { get; set; }
        public string nanos { get; set; }
    }

    public class TieredRate
    {
        public string startUsageAmount { get; set; }
        public UnitPrice unitPrice { get; set; }
    }

    public class PricingExpression
    {
        public string usageUnit { get; set; }
        public string usageUnitDescription { get; set; }
        public string displayQuantity { get; set; }
        public List<TieredRate> tieredRates { get; set; }
    }

    public class AggregationInfo
    {
        public string aggregationLevel { get; set; }
        public string aggregationInterval { get; set; }
        public string aggregationCount { get; set; }
    }

    public class PricingInfo
    {
        public string effectiveTime { get; set; }
        public string summary { get; set; }
        public PricingExpression pricingExpression { get; set; }
        public AggregationInfo aggregationInfo { get; set; }
        public string currencyConversionRate { get; set; }
    }

    public class Sku
    {
        public string name { get; set; }
        public string skuId { get; set; }
        public string description { get; set; }
        public Category category { get; set; }
        public List<string> serviceRegions { get; set; }
        public List<PricingInfo> pricingInfo { get; set; }
        public string serviceProviderName { get; set; }
    }

    public class ServiceSkuResponse
    {
        public List<Sku> Skus { get; set; }
    }
}