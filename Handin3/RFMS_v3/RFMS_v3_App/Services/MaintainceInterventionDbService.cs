using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace RFMS_v3_App.Services;

public class MaintainceInterventionDbService
{
    private readonly IMongoCollection<MaintenanceIntervention> _maintainceInterventionCollection;

    public MaintainceInterventionDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _maintainceInterventionCollection = database.GetCollection<MaintenanceIntervention>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<MaintenanceIntervention>> GetAsync()
    {
        return await _maintainceInterventionCollection.Find(maintenanceIntervention => true).ToListAsync();
    }

    public async Task<MaintenanceIntervention> GetAsync(string id)
    {
        return await _maintainceInterventionCollection
                        .Find(maintenanceIntervention => maintenanceIntervention.Id == id)
                        .FirstOrDefaultAsync();
    }

    public MaintenanceIntervention CreateAsync(MaintenanceIntervention maintenanceIntervention)
    {
        _maintainceInterventionCollection.InsertOne(maintenanceIntervention);
        return maintenanceIntervention;
    }

    public async Task<MaintenanceIntervention> UpdateAsync(string id, MaintenanceIntervention maintenanceInterventionIn)
    {
        await _maintainceInterventionCollection.ReplaceOneAsync(citizen => citizen.Id == id, maintenanceInterventionIn);
        return maintenanceInterventionIn;
    }

    public async Task<DeleteResult> RemoveAsync(MaintenanceIntervention maintenanceInterventionIn)
    {
        return await _maintainceInterventionCollection
            .DeleteOneAsync(maintenanceIntervention
                => maintenanceIntervention.Id == maintenanceInterventionIn.Id);
    }

    public async Task<DeleteResult> RemoveAsync(string id)
    {
        return await _maintainceInterventionCollection
            .DeleteOneAsync(maintenanceIntervention => maintenanceIntervention.Id == id);
    }


}
