using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class Traveller
    {
        private readonly IMongoCollection<TravellerModel> _travellers;

        //Database connection
        public Traveller(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _travellers = mongoDatabase.GetCollection<TravellerModel>(
                datbaseConnection.Value.TravellerCollectionName);
        }
        //Method to add traveller details
        //Profile Creation
        public TravellerModel Create(TravellerModel traveller)
        {
            _travellers.InsertOne(traveller);
            return traveller;
        }

        //Profile Deletion
        public void Delete(string Id)
        {
            _travellers.DeleteOne(traveller => traveller.Id == Id);
        }

        public List<TravellerModel> Get()
        {
            return _travellers.Find(traveller => true).ToList();
        }

        //Get traveller details
        public TravellerModel Get(string Id)
        {
            return _travellers.Find(traveller => traveller.Id == Id).FirstOrDefault();
        }

        //Profile Updation
        public void Update(string Id, TravellerModel traveller)
        {
            _travellers.ReplaceOne(traveller => traveller.Id == Id, traveller);
        }
    }
}
