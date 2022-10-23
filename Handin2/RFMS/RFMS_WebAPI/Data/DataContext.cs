using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RFMS_WebAPI.Models;

public class DataContext : DbContext
{
    public DataContext (DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Booking> Bookings { get; set; } = default!;

    public DbSet<Citizen> Citizens { get; set; } = default!;

    public DbSet<Facility> Facilities { get; set; } = default!;
    public DbSet<Reservation> Reservations { get; set; } = default!;
}
