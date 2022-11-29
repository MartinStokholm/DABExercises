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
        _citizenCollection = database.GetCollection<Citizen>("CitizenCollection");
    }
    
    public async Task<List<Citizen>> GetAsync()
    {
        return await _citizenCollection.Find(citizen => true).ToListAsync();
    }

    public async Task CreateAsync(CitizenNoIdDto citizen)
    {

        var citizenInsert = new Citizen
        {
            FirstName = citizen.FirstName,
            LastName = citizen.LastName,
            Email = citizen.Email,
            Category = citizen.Category,
            CVR = citizen.CVR,
            CPR = citizen.CPR,
            PhoneNumber = citizen.PhoneNumber,
        };

        await _citizenCollection.InsertOneAsync(citizenInsert);
        return;
    }
}
