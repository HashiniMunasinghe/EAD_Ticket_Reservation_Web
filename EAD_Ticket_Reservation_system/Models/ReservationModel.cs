using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class ReservationModel
    {
        //Reservation details
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("trainCode")]
        public string? TrainCode { get; set; }

        [BsonElement("startingFrom")]
        public string? StartingFrom { get; set; }

        [BsonElement("destination")]
        public string? Destination { get; set; }

        [BsonElement("class")]
        public string? Class { get; set; }

        [BsonElement("seats")]
        public int? Seats { get; set; }
    }
}
