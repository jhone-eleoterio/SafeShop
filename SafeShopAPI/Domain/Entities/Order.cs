namespace SafeShopAPI.Domain.Entities
{
    public class Order : Entity
    {
        protected Order() { }

        public Guid ProductId { get; set; }
        public string? NumberOrder { get; set; }
        public int Quantity { get; private set; }

        public Order(string numberOrder, Guid productId, int quantity)
        {
            NumberOrder = GenerateRandomNumber(numberOrder);
            ProductId = productId;
            Quantity = quantity;
        }

        public void Update(int quantity) => Quantity = quantity;

        public string GenerateRandomNumber(string numberOrder)
        {
            char[] alphanumericChars =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            string newValueOrder = numberOrder;

            Random random = new Random();

            for (int i = 0; i < 12; i++)
                newValueOrder += alphanumericChars[random.Next(alphanumericChars.Length)];

            return newValueOrder;
        }
    }
}
