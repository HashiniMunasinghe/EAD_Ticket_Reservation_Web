﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EAD_Ticket_Reservation_system.Models
{
    [BsonIgnoreExtraElements]
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("role")]
        public string? Role { get; set; }
    }
}
