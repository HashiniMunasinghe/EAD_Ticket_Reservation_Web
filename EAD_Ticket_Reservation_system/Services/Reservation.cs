using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class Reservation
    {
        private readonly IMongoCollection<ReservationModel> _reservation;

        //Mongo db Connection
        public Reservation(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _reservation = mongoDatabase.GetCollection<ReservationModel>(
                datbaseConnection.Value.ReservationCollectionName);
        }
        //Method to add a reservation
        public ReservationModel Create(ReservationModel reservation)
        {
            _reservation.InsertOne(reservation);
            return reservation;
        }

        //Method to cancel a reservation
        public void Delete(string Id)
        {
            _reservation.DeleteOne(reservation => reservation.Id == Id);
        }

        //Method to get Reservation list
        public List<ReservationModel> Get()
        {
            return _reservation.Find(reservation => true).ToList();
        }

        //Method to get single reservation by Id
        public ReservationModel Get(string Id)
        {
            return _reservation.Find(reservation => reservation.Id == Id).FirstOrDefault();
        }

        //Method to update reservation details
        public void Update(string Id, ReservationModel reservation)
        {
            _reservation.ReplaceOne(reservation => reservation.Id == Id, reservation);
        }
    }
}
