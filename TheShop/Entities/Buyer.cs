namespace TheShop.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public double MaxExpectedPrice { get; set; }

        public Buyer(int id, double maxExpectedPrice)
        {
            Id = id;
            MaxExpectedPrice = maxExpectedPrice;
        }
    }
}
