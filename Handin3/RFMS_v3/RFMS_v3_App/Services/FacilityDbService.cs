using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

namespace RFMS_v3_App.Services;

public class FacilityDbService
{
    private readonly IMongoCollection<Facility> _facilityCollection;

    public FacilityDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _facilityCollection = database.GetCollection<Facility>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<Facility>> GetAsync()
    {
        return await _facilityCollection.Find(citizen => true).ToListAsync();
    }

    public async Task<Facility> Get(string id)
    {
        return await _facilityCollection.Find(citizen => citizen.Id == id).FirstOrDefaultAsync();
    }

    public Facility Create(Facility facility)
    {
        _facilityCollection.InsertOne(facility);
        return facility;
    }


    public async Task CreateAsync(FacilityAddressAndNameDto facility)
    {

        var facilityInsert = new Facility
        {
            Name = facility.Name,
            //DTO Dont match yet
        };

        await _facilityCollection.InsertOneAsync(facilityInsert);
        return;
    }

    public async Task<Facility> UpdateAsync(string id, Facility facilityIn)
    {
        await _facilityCollection.ReplaceOneAsync(facility => facility.Id == id, facilityIn);
        return facilityIn;
    }

    public async Task<DeleteResult> RemoveAsync(Facility citizenIn)
    {
        return await _facilityCollection.DeleteOneAsync(facility => facility.Id == citizenIn.Id);
    }

    public async Task<DeleteResult> AsyncRemove(string id)
    {
        return await _facilityCollection.DeleteOneAsync(facility => facility.Id == id);
    }


}
