using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class ScheduleModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("trainCode")]
        public string? TrainCode { get; set; }

        [BsonElement("trainType")]
        public string? TrainType { get; set; }

        [BsonElement("startingFrom")]
        public string? StartingFrom { get; set; }

        [BsonElement("destination")]
        public string? Destination { get; set; }

        [BsonElement("departs")]
        public string? Departs { get; set; }

        [BsonElement("arrives")]
        public string? Arrives { get; set; }
    }
}
