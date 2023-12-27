namespace PhoneMysql.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public DateTime orderDate { get; set; }
    }
}
