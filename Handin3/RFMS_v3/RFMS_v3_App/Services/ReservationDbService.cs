using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace RFMS_v3_App.Services;

public class ReservationDbService
{
    private readonly IMongoCollection<Reservation> _reservationCollection;

    public ReservationDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _reservationCollection = database.GetCollection<Reservation>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<Reservation>> GetAsync()
    {
        return await _reservationCollection.Find(reservation => true).ToListAsync();
    }

    public async Task<Reservation> Get(string id)
    {
        return await _reservationCollection.Find(reservation => reservation.Id == id).FirstOrDefaultAsync();
    }

    public Reservation Create(Reservation reservation)
    {
        _reservationCollection.InsertOne(reservation);
        return reservation;
    }

    public async Task<Reservation> Update(string id, Reservation reservationIn)
    {
        await _reservationCollection.ReplaceOneAsync(reservation => reservation.Id == id, reservationIn);
        return reservationIn;
    }

    public async Task<DeleteResult> Remove(Reservation citizenIn)
    {
        return await _reservationCollection.DeleteOneAsync(reservation => reservation.Id == citizenIn.Id);
    }

    public async Task<DeleteResult> Remove(string id)
    {
        return await _reservationCollection.DeleteOneAsync(reservation => reservation.Id == id);
    }


}
