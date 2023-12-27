namespace PhoneMysql.Data.Entities
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string storage { get; set; }
        public string RAM { get; set; }
        public double screenSize { get; set; }
        public string camera { get; set; }
        public int batteryCapacity { get; set; }
        public double price { get; set; }
    }
}