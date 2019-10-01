namespace WebAPIFundamental.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public string SKU { get; set; }

        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

    }
}