using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace RFMS_v3_App.Services;

public class FacilityDbService
{
    private readonly IMongoCollection<Citizen> _facilityCollection;

    public FacilityDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _facilityCollection = database.GetCollection<Citizen>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<Citizen>> GetAsync()
    {
        return await _facilityCollection.Find(citizen => true).ToListAsync();
    }
    
    public async Task<Citizen> Get(string id)
    {
        return await _facilityCollection.Find(citizen => citizen.Id == id).FirstOrDefaultAsync();
    }

    public Citizen Create(Citizen citizen)
    {
        _facilityCollection.InsertOne(citizen);
        return citizen;
    }
    
    public async Task<Citizen> Update(string id, Citizen citizenIn)
    {
        await _facilityCollection.ReplaceOneAsync(citizen => citizen.Id == id, citizenIn);
        return citizenIn;
    }

    public async Task<DeleteResult> Remove(Citizen citizenIn)
    {
        return await _facilityCollection.DeleteOneAsync(citizen => citizen.Id == citizenIn.Id);
    }

    public async Task<DeleteResult> Remove(string id)
    {
        return await _facilityCollection.DeleteOneAsync(citizen => citizen.Id == id);
    }


}
