using System;
using CoreTravel.Models;

namespace CoreTravel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User>? Users { get; set; }

        public DbSet<Token>? Tokens { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<City> Cities{ get; set; }

        public DbSet<TicketWay> TicketWays { get; set; }

        public DbSet<TravelService> TravelServices { get; set; }

        public DbSet<Direction> Directions { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<BookingStatus> BookingStatuses { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<CustomerHasBooking> CustomerHasBookings { get; set; }

        public DbSet<PaymentInfo> PaymentInfos { get; set; }

        public DbSet<TripPurpose> TripPurposes { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

    }


}

