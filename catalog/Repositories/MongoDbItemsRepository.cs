using System;
using System.Collections.Generic;
using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{


  // var settings = MongoClientSettings.FromConnectionString("mongodb+srv://salci:<password>@catalog.mcmem.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
  // var client = new MongoClient(settings);
  // var database = client.GetDatabase("test");


  public class MongoDbItemsRepository : IInMemItemsRepository
  {



    private const string databaseName = "catalog";
    private const string collectionName = "itemsCollection";

    private readonly IMongoCollection<Item> itemsCollection;

    private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;


    public MongoDbItemsRepository(IMongoClient mongoClient)
    {
      IMongoDatabase database = mongoClient.GetDatabase(databaseName);
      itemsCollection = database.GetCollection<Item>(collectionName);

    }
    public void CreateItem(Item item)
    {
      itemsCollection.InsertOne(item);
    }

    public void DeleteItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      itemsCollection.DeleteOne(filter);

    }

    public Item GetItem(Guid id)
    {
      var filter = filterBuilder.Eq(item => item.Id, id);
      return itemsCollection.Find(filter).SingleOrDefault();
    }

    public IEnumerable<Item> GetItems()
    {
      return itemsCollection.Find(new BsonDocument()).ToList();
    }

    public void UpdateItem(Item item)
    {
      var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
      itemsCollection.ReplaceOne(filter, item);
    }
  }
}