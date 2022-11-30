using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

namespace RFMS_v3_App.Services;

public class MaintainceInterventionDbService
{
    private readonly IMongoCollection<MaintenanceIntervention> _maintainceInterventionCollection;
    private readonly IMongoCollection<Facility> _facilityCollection;
    
    public MaintainceInterventionDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _maintainceInterventionCollection = database.GetCollection<MaintenanceIntervention>("MaintenanceInterventionsCollection");
        _facilityCollection = database.GetCollection<Facility>("FacilitiesCollection");

    }
    public async Task<List<MaintenanceIntervention>> GetHistoryAsync()
    {
        return await _maintainceInterventionCollection.Find(maintenanceIntervention => true).ToListAsync();
    }

    public async Task<MaintenanceIntervention> CreateAsync(MaintenanceInterventionCreateDto maintenanceIntervention)
    {
        var newMaintenanceIntervention = new MaintenanceIntervention();
        var facility = _facilityCollection.Find(facility => facility.Name == maintenanceIntervention.FacilityName).FirstOrDefault();
        
        newMaintenanceIntervention.Id = ObjectId.GenerateNewId().ToString();
        newMaintenanceIntervention.Description = maintenanceIntervention.Description;
        newMaintenanceIntervention.Date = maintenanceIntervention.Date;
        newMaintenanceIntervention.Facility = facility;

        await _maintainceInterventionCollection.InsertOneAsync(newMaintenanceIntervention);
        
        return newMaintenanceIntervention;
    }
}
