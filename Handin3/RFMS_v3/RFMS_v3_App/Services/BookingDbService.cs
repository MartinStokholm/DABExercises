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
    
    public async Task<List<BookingDetailsDto>> GetBookingDetailsAsync()
    {
        var bookings = await _bookingService.Find(booking => true).ToListAsync();

        var result = new List<BookingDetailsDto>();

        foreach (var booking in bookings) 
        {
            result.Add(new BookingDetailsDto
            {
                FacilityName = booking.Facility.Name,
                Citizen = booking.Citizen,
                BookingStartTime = booking.BookingStartTime,
                BookingEndTime = booking.BookingEndTime,
            });
        }
        
        return result;
    }

    public async Task<List<BookingWithCitizensCPR>> GetBookingsWithCitizensCPRAsync()
    {
        var bookings = await _bookingService.Find(booking => true).ToListAsync();
        var result = new List<BookingWithCitizensCPR>();
        foreach (var booking in bookings)
        {
            result.Add(new BookingWithCitizensCPR
            {
                Id = booking.Id,
                BookingStartTime = booking.BookingStartTime,
                BookingEndTime = booking.BookingEndTime,
                NumberOfPeople = booking.NumberOfPeople,
                CitizensCPR = booking.CitizensCPR,
            });
        }
        return result;
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
}
