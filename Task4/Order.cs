namespace Task4
{
    internal class Order
    {
        private static int _index = 1001;

        public int Id { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            Id = _index++;
            Status = OrderStatus.Pending;
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }
    }
}
