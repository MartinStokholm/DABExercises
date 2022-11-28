using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;

namespace RFMS_v3_App.Services;

public class CitizenDbService
{
    private readonly IMongoCollection<Citizen> _citizenCollection;

    public CitizenDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _citizenCollection = database.GetCollection<Citizen>(mongoDBSettings.Value.CollectionName);
    }
    public List<Citizen> Get()
    {
        return _citizenCollection.Find(citizen => true).ToList();
    }
    
    public Citizen Get(string id)
    {
        return _citizenCollection.Find(citizen => citizen.Id == id).FirstOrDefault();
    }

    public Citizen Create(Citizen citizen)
    {
        _citizenCollection.InsertOne(citizen);
        return citizen;
    }
    
    public void Update(string id, Citizen citizenIn)
    {
        _citizenCollection.ReplaceOne(citizen => citizen.Id == id, citizenIn);
    }

    public void Remove(Citizen citizenIn)
    {
        _citizenCollection.DeleteOne(citizen => citizen.Id == citizenIn.Id);
    }

    public void Remove(string id)
    {
        _citizenCollection.DeleteOne(citizen => citizen.Id == id);
    }


}
