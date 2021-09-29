namespace Catalog.Settings
{


  public class MongoDbSettings
  {
    // var settings = MongoClientSettings.FromConnectionString("mongodb+srv://salci:salci@catalog.mcmem.mongodb.net/items?retryWrites=true&w=majority");

    public string Host { get; set; }
    public int Port { get; set; }

    public string ConnectionString
    {
      get
      {
        return "mongodb+srv://salci:salci@catalog.mcmem.mongodb.net/items?retryWrites=true&w=majority";

      }
    }



  }
}