public class Distributor
{
    public int DistributorId { get; set; }
    public string ServiceVendorId { get; set; }
    public string DistributorName { get; set; }
    public string OtherDistributorDetails { get; set; }

    public ServiceVendor ServiceVendor { get; set; }
}