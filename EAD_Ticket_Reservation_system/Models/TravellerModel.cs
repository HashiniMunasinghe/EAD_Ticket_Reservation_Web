using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class TravellerModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nic")]
        public string? NIC { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("mobileN0")]
        public string? MobileNo { get; set; }

        [BsonElement("accStatus")]
        public string? AccStatus { get; set; }

    }
}
