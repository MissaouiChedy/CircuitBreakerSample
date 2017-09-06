using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CircuitBreakerSample
{
    public class DatabaseConnectionFactory
    {
        public static string DbName => "CBDatabase";
        public static string DbUrl => "127.0.0.1";

        private static MongoClient _client = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress(DbUrl),
            SocketTimeout = new TimeSpan(0, 0, 0, 2),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 2),
            HeartbeatTimeout = new TimeSpan(0, 0, 0, 2),
            ServerSelectionTimeout = new TimeSpan(0, 0, 0, 2)
        });

        public static MongoClient Connection => _client;
    }
}