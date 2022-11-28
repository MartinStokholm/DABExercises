using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

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
    public async Task<List<Citizen>> GetAsync()
    {
        return await _citizenCollection.Find(citizen => true).ToListAsync();
    }

    public async Task<Citizen> GetAsync(string id)
    {
        return await _citizenCollection.Find(citizen => citizen.Id == id).FirstOrDefaultAsync();
    }

    public Citizen Create(Citizen citizen)
    {
        _citizenCollection.InsertOne(citizen);
        return citizen;
    }

    public async Task CreateAsync(CitizenNoBookingsDto citizen)
    {

        var citizenInsert = new Citizen
        {
            FirstName = citizen.FirstName,
            LastName = citizen.LastName,
            Email = citizen.Email,
            Category = citizen.Category,
            CVR = citizen.CVR,
            PhoneNumber = citizen.PhoneNumber,
        };

        await _citizenCollection.InsertOneAsync(citizenInsert);
        return;
    }


    public async Task<Citizen> UpdateAsync(string id, Citizen citizenIn)
    {
        await _citizenCollection.ReplaceOneAsync(citizen => citizen.Id == id, citizenIn);
        return citizenIn;
    }



    public async Task<DeleteResult> RemoveAsync(Citizen citizenIn)
    {
        return await _citizenCollection.DeleteOneAsync(citizen => citizen.Id == citizenIn.Id);
    }

    public async Task<DeleteResult> RemoveAsync(string id)
    {
        return await _citizenCollection.DeleteOneAsync(citizen => citizen.Id == id);
    }


}
