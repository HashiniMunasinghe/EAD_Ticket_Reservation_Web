using EAD_Ticket_Reservation_system.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EAD_Ticket_Reservation_system.Services
{
    public class Schedule
    {
        private readonly IMongoCollection<ScheduleModel> _schedule;

        //MongoDB Connection
        public Schedule(IOptions<DatabaseConnection> datbaseConnection)
        {
            var mongoClient = new MongoClient(
                datbaseConnection.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                datbaseConnection.Value.DatabaseName);

            _schedule = mongoDatabase.GetCollection<ScheduleModel>(
                datbaseConnection.Value.ScheduleCollectionName);
        }

        //Method to add schedule details
        public ScheduleModel Create(ScheduleModel schedule)
        {
            _schedule.InsertOne(schedule);
            return schedule;
        }
        
        //Method to delete schedule details
        public void Delete(string Id)
        {
            _schedule.DeleteOne(schedule => schedule.Id == Id);
        }

        //Get a list of schedules
        public List<ScheduleModel> Get()
        {
            return _schedule.Find(schedule => true).ToList();
        }

        //Get a single schedule details by Id
        public ScheduleModel Get(string Id)
        {
            return _schedule.Find(schedule => schedule.Id == Id).FirstOrDefault();
        }

        //Update Schedule details
        public void Update(string Id, ScheduleModel schedule)
        {
            _schedule.ReplaceOne(schedule => schedule.Id == Id, schedule);
        }
    }
}

