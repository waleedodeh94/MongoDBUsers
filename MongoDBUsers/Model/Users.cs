using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBUsers.Model
{
    //this class represent all data for user
    public class Users
    {
        [BsonId]
        public ObjectId _Id { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string username { get; set; }

        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
   
        public Address address { get; set; }
        
        public Company company { get; set; }
     
    }
}