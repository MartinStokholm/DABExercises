using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace RFMS_v3_App.Services;

public class BookingDbService
{
    private readonly IMongoCollection<Booking> _bookingService;

    public BookingDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _bookingService = database.GetCollection<Booking>(mongoDBSettings.Value.CollectionName);
    }
    public async Task<List<Booking>> GetAsync()
    {
        return await _bookingService.Find(booking => true).ToListAsync();
    }

    public async Task<Booking> Get(string id)
    {
        return await _bookingService.Find(booking => booking.Id == id).FirstOrDefaultAsync();
    }

    public Booking Create(Booking booking)
    {
        _bookingService.InsertOne(booking);
        return booking;
    }

    public async Task<Booking> Update(string id, Booking bookingIn)
    {
        await _bookingService.ReplaceOneAsync(v => booking.Id == id, bookingIn);
        return bookingIn;
    }

    public async Task<DeleteResult> Remove(Booking bookingServiceIn)
    {
        return await _bookingService.DeleteOneAsync(booking => booking.Id == bookingServiceIn.Id);
    }

    public async Task<DeleteResult> Remove(string id)
    {
        return await _bookingService.DeleteOneAsync(booking => booking.Id == id);
    }


}
