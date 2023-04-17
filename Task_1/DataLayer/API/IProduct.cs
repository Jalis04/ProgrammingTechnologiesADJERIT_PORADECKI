namespace DataLayer.API
{
    public interface IProduct
    {
        string id { get; set; }
        string productName { get; set; }
        string productDescription { get; set; }
        float price { get; set; }
    }

}
