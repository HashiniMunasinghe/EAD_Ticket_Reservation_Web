using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class User
    {
        private readonly IMongoCollection<UserModel> _user;

        //Mongo db connection
        public User(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _user = mongoDatabase.GetCollection<UserModel>(
                datbaseConnection.Value.UserCollectionName);
        }

        //User creation
        public UserModel Create(UserModel user)
        {
            _user.InsertOne(user);
            return user;
        }

        //User delete
        public void Delete(string Id)
        {
            _user.DeleteOne(user => user.Id == Id);
        }

        //Method to get list of users
        public List<UserModel> Get()
        {
            return _user.Find(user => true).ToList();
        }

        //Get individual user by Id
        public UserModel Get(string Id)
        {
            return _user.Find(user => user.Id == Id).FirstOrDefault();
        }

        //Method to update the user
        public void Update(string Id, UserModel user)
        {
            _user.ReplaceOne(user => user.Id == Id, user);
        }
    }
}
