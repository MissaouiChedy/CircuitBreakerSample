using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CircuitBreakerSample.MongoDatabase
{
    public class MongoPersonRepository : IPersonRepository
    {
        private MongoClient _client;
        public MongoPersonRepository(MongoClient client) 
        {
            _client = client;
            
        }
        public virtual List<Person> Read()
        {
            return _client
                    .GetDatabase(DatabaseConnectionFactory.DbName)
                    .GetCollection<Person>("persons")
                    .Find(new BsonDocument())
                    .ToList();
        }
        public virtual void Write(Person person) 
        {
            _client
              .GetDatabase(DatabaseConnectionFactory.DbName)
              .GetCollection<Person>("persons")
              .InsertOne(person);
        }
    }
}