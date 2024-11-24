public class Customer
{
    public int CustomerId { get; set; }
    public string CompanyId { get; set; }
    public string CustomerTypeCode { get; set; }
    public string EndUserId { get; set; }
    public string CustomerDetails { get; set; }

    public RefCustomerType CustomerType { get; set; }
}