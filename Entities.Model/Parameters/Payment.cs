using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Model.Parameters
{

    public class Payment
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Identification { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public string ExpirationDate { get; set; }

        public DateTime CreationDate { get; set; }

    }
}
