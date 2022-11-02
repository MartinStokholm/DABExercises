using Microsoft.EntityFrameworkCore;
using RFMS_v2_app.Models;

    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; } = default!;

        public DbSet<Citizen> Citizens { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<MaintenanceIntervention> MaintenanceInterventions { get; set; }
    }
