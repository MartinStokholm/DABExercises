using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using RFMS_v3_App.Models;
using Microsoft.AspNetCore.Mvc;
using RFMS_v3_App.Models.Dto;

namespace RFMS_v3_App.Services;

public class BookingDbService
{
    private readonly IMongoCollection<Booking> _bookingService;
    private readonly IMongoCollection<Facility> _facilityService;
    private readonly IMongoCollection<Citizen> _citizenService;
    
    public BookingDbService(IOptions<MongoDbSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _bookingService = database.GetCollection<Booking>("BookingCollection");
        _facilityService = database.GetCollection<Facility>("FacilitiesCollection");
        _citizenService = database.GetCollection<Citizen>("CitizenCollection");
    }
    public async Task<List<Booking>> GetAsync()
    {
        return await _bookingService.Find(booking => true).ToListAsync();
    }

    public async Task<Booking> GetAsync(string id)
    {
        return await _bookingService.Find(booking => booking.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Booking> GetBookingParticipantsCPRAsync(string id)
    {
        return await _bookingService.Find(booking => booking.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Booking> CreateAsync(BookingCreateDto booking)
    {
        var facility = _facilityService.Find(facility => facility.Name == booking.FacilityName).FirstOrDefault();
        var citizen = _citizenService.Find(citizen => citizen.FirstName == booking.BookedByCitizenFirstName).FirstOrDefault();
        
        var numberOfPeople = booking.CitizenFirstNames.Count;
        
        var result = new Booking
        {
            Id = ObjectId.GenerateNewId().ToString(),
            BookingStartTime = booking.BookingStartTime,
            BookingEndTime = booking.BookingEndTime,
            NumberOfPeople = numberOfPeople,
            Citizen = citizen,
            Facility = facility
        };
        
        var citizens = _citizenService.Find(citizen => booking.CitizenFirstNames.Contains(citizen.FirstName)).ToListAsync();

        foreach (var item in citizens.Result)
        {
            result.CitizensCPR.Add(item.CPR);
        }
        await _bookingService.InsertOneAsync(result);
        
        return result;
    }


    public async Task<Booking> UpdateAsync(string id, Booking bookingIn)
    {
        await _bookingService.ReplaceOneAsync(booking => booking.Id == id, bookingIn);
        return bookingIn;
    }

    public async Task<DeleteResult> RemoveAsync(Booking bookingServiceIn)
    {
        return await _bookingService.DeleteOneAsync(booking => booking.Id == bookingServiceIn.Id);
    }

    public async Task<DeleteResult> RemoveAsync(string id)
    {
        return await _bookingService.DeleteOneAsync(booking => booking.Id == id);
    }


}
