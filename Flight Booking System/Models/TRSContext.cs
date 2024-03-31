using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Rail_Booking_System.Models;

namespace Rail_Booking_System.Models
{
    public class TRSContext : DbContext
    {
        public TRSContext() :base("dbcon")
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Train> Trains { get; set;}
        public DbSet<UserLogin> UserLogins { get; set;}
        public DbSet<Rail> Rails { get; set;}   
        public DbSet<Station> Stations { get; set;} 
        public DbSet<Schedule> Schedules { get; set;}

    }
}