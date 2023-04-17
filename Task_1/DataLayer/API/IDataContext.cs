namespace DataLayer.API
{
    public interface IDataContext
    {   
        //Catalog is the list of products
        public Dictionary<string, IProduct> catalog { get; set; }
        public List<IEvent> events { get; set; }
        public List<IState> states { get; set; }
        public List<IUser> users { get; set; }

    }
}
