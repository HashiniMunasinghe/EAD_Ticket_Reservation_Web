using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class Train
    {
        private readonly IMongoCollection<TrainModel> _train;

        //Database Connection
        public Train(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _train = mongoDatabase.GetCollection<TrainModel>(
                datbaseConnection.Value.TrainCollectionName);
        }
        //Method to Add train Details
        public TrainModel Create(TrainModel train)
        {
            _train.InsertOne(train);
            return train;
        }

        //Method to delete train details
        public void Delete(string Id)
        {
            _train.DeleteOne(train => train.Id == Id);
        }

        public List<TrainModel> Get()
        {
            return _train.Find(train => true).ToList();
        }

        //Get train Details 
        public TrainModel Get(string Id)
        {
            return _train.Find(train => train.Id == Id).FirstOrDefault();
        }

        //Update Train details
        public void Update(string Id, TrainModel train)
        {
            _train.ReplaceOne(train => train.Id == Id, train);
        }
    }
}
