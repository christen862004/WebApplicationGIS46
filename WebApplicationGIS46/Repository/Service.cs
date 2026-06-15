namespace WebApplicationGIS46.Repository
{
    public class Service : IService
    {
        public string ID { get; set; }
        //when object create take unique id
        public Service()
        {
            ID = Guid.NewGuid().ToString();//23442-iuiui-8989
        }
    }
}
