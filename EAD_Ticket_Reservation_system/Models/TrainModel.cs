using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class TrainModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("trainCode")]
        public string? TrainCode { get; set; }

        [BsonElement("trainType")]
        public string? TrainType { get; set; }

        [BsonElement("trainName")]
        public string? TrainName { get; set; }

        [BsonElement("status")]
        public string? Status { get; set; }
    }
}
