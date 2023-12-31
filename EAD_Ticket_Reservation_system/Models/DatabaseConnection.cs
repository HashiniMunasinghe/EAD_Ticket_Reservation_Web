﻿namespace EAD_Ticket_Reservation_system.Models
{
    public class DatabaseConnection
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ClientCollectionName { get; set; } = null!;

        public string TravellerCollectionName { get; set; } = null!;

        public string TrainCollectionName { get; set; } = null!;
        
        public string UserCollectionName { get; set; } = null!;

        public string ReservationCollectionName { get; set; } = null!;

        public string ScheduleCollectionName { get; set; } = null!;

        //public string ReservationCollectionName { get; set; } = null!;


    }
}
