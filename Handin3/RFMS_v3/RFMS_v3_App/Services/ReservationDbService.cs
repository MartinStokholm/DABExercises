using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace RFMS_v3_App.Services;

public class ReservationDbService
{
    private readonly IMongoCollection<Citizen> _reservationCollection;

    public ReservationDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _reservationCollection = database.GetCollection<Citizen>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<Citizen>> GetAsync()
    {
        return await _reservationCollection.Find(citizen => true).ToListAsync();
    }
    
    public async Task<Citizen> Get(string id)
    {
        return await _reservationCollection.Find(citizen => citizen.Id == id).FirstOrDefaultAsync();
    }

    public Citizen Create(Citizen citizen)
    {
        _reservationCollection.InsertOne(citizen);
        return citizen;
    }
    
    public async Task<Citizen> Update(string id, Citizen citizenIn)
    {
        await _reservationCollection.ReplaceOneAsync(citizen => citizen.Id == id, citizenIn);
        return citizenIn;
    }

    public async Task<DeleteResult> Remove(Citizen citizenIn)
    {
        return await _reservationCollection.DeleteOneAsync(citizen => citizen.Id == citizenIn.Id);
    }

    public async Task<DeleteResult> Remove(string id)
    {
        return await _reservationCollection.DeleteOneAsync(citizen => citizen.Id == id);
    }


}
