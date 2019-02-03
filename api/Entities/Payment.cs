using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FTAdverts.Entities
{
    public class Payment
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Contact { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }
		
		public DateTime Date { get; set; }

    }
}