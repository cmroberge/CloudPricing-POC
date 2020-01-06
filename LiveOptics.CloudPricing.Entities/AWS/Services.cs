using System;
using System.Collections.Generic;

namespace LiveOptics.CloudPricing.Entities.AWS
{
    public class Attributes
    {
        public string servicecode { get; set; }
        public string location { get; set; }
        public string locationType { get; set; }
        public string instanceType { get; set; }
        public string currentGeneration { get; set; }
        public string instanceFamily { get; set; }
        public string vcpu { get; set; }
        public string physicalProcessor { get; set; }
        public string clockSpeed { get; set; }
        public string memory { get; set; }
        public string storage { get; set; }
        public string networkPerformance { get; set; }
        public string processorArchitecture { get; set; }
        public string tenancy { get; set; }
        public string operatingSystem { get; set; }
        public string licenseModel { get; set; }
        public string usagetype { get; set; }
        public string operation { get; set; }
        public string capacitystatus { get; set; }
        public string dedicatedEbsThroughput { get; set; }
        public string ecu { get; set; }
        public string enhancedNetworkingSupported { get; set; }
        public string instancesku { get; set; }
        public string intelAvxAvailable { get; set; }
        public string intelAvx2Available { get; set; }
        public string intelTurboAvailable { get; set; }
        public string normalizationSizeFactor { get; set; }
        public string preInstalledSw { get; set; }
        public string processorFeatures { get; set; }
        public string servicename { get; set; }
    }

    public class Product
    {
        public string sku { get; set; }
        public string productFamily { get; set; }
        public Attributes attributes { get; set; }
    }

    public class PricePerUnit
    {
        public string USD { get; set; }
    }

    public class PriceDimensionDetail
    {
        public string rateCode { get; set; }
        public string description { get; set; }
        public string beginRange { get; set; }
        public string endRange { get; set; }
        public string unit { get; set; }
        public PricePerUnit pricePerUnit { get; set; }
        public List<object> appliesTo { get; set; }
    }

    public class PriceDimensions
    {
        public PriceDimensionDetail priceDetail { get; set; }
    }

    public class TermAttributes
    {
    }

    public class ProductDemandDetailInformation
    {
        public string offerTermCode { get; set; }
        public string sku { get; set; }
        public DateTime effectiveDate { get; set; }
        public PriceDimensions priceDimensions { get; set; }
        public TermAttributes termAttributes { get; set; }
    }

    public class ProductDemandDetail
    {
        public ProductDemandDetailInformation product { get; set; }
    }

    public class TermDetail
    {
        public ProductDemandDetail[] product { get; set; }
    }

    public class Terms
    {
        public TermDetail OnDemand { get; set; }
        public TermDetail Reserved { get; set; }
    }

    public class Products
    {
        public Product[] product { get; set; }
        public Terms terms { get; set; }
    }

    public class RootObject
    {
        public string formatVersion { get; set; }
        public string disclaimer { get; set; }
        public string offerCode { get; set; }
        public string version { get; set; }
        public DateTime publicationDate { get; set; }
        public Products products { get; set; }
    }
}