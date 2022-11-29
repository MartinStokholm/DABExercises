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
        _facilityCollection = database.GetCollection<Facility>("FacilitiesCollection");
    }
    public async Task<List<FacilityGPSNameAndKindDto>> GetFacilitiesOrderByKindAsync()
    {
        var facilitiesSorted = await _facilityCollection
            .Find(facility => true)
            
            .SortBy(f => f.Kind)
            .ToListAsync();
        
        var result = facilitiesSorted.Select(facility => new FacilityGPSNameAndKindDto
        {
            Name = facility.Name,
            Latitude = facility.Latitude,
            Longitude = facility.Longitude,
            Kind = facility.Kind,
            

        })        
        .ToList();
        
        return result;
    }
    public async Task<List<FacilityGPSAndNameDto>> GetAvailableFacilitiesGPSAndNameAsync()
    {
        var facilitiesSorted = await _facilityCollection
            .Find(facility => true)
            .ToListAsync();
        
        var result = new List<FacilityGPSAndNameDto>();

        foreach (var facility in facilitiesSorted)
        {
            string? name = facility.Name;
            result.Add(new FacilityGPSAndNameDto
            {
                Name = name,
                Latitude = facility.Latitude,
                Longitude = facility.Longitude,
            });
        }

        return result;
    }


    public async Task<List<Facility>> GetAsync()
    {
        return await _facilityCollection.Find(facility => true).ToListAsync();
    }
    
    public async Task<Facility> GetAsync(string id)
    {
        return await _facilityCollection.Find(facility => facility.Id == id).FirstOrDefaultAsync();
    }

    public Facility Create(Facility facility)
    {
        _facilityCollection.InsertOne(facility);
        return facility;
    }

    public async Task CreateAsync(FacilityNoIdDto facility)
    {
        var facilityToCreate = new Facility
        {
            Name = facility.Name,
            Kind = facility.Kind,
            Longitude = facility.Longitude,
            Latitude = facility.Latitude,
            Reserved = facility.Reserved,
            UsageRules = facility.UsageRules,
            Items = facility.Items
        };
        await _facilityCollection.InsertOneAsync(facilityToCreate);
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

    public async Task<DeleteResult> RemoveAsync(string id)
    {
        return await _facilityCollection.DeleteOneAsync(facility => facility.Id == id);
    }


}
