public class CustomerMachine
{
    public int MachineId { get; set; }
    public int CustomerId { get; set; }
    public string MachineType { get; set; }
    public string MachineDescription { get; set; }

    public Customer Customer { get; set; }
}