using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FTAdverts.Entities
{
    public class PaymentCreationDTO
    {
        public string Contact { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }
    }
}