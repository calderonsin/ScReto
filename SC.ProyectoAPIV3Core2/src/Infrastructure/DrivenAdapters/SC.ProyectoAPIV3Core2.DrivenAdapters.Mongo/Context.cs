//using MongoDB.Driver;
//using MongoDB.Bson.Serialization;
//using System;
//using MongoDB.Bson;
//using System.Linq;
//using System.Collections.Generic;
//namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Mongo.MongodbRepository
//{

//    public class Context
//    {
//    private readonly MongoClient _mongoClient;
//    private readonly IMongoDatabase _database;


//    public Context(string connectionString, string databaseName)
//    {

//        _mongoClient = new MongoClient(connectionString);
//        _database = _mongoClient.GetDatabase(databaseName);
//        //Map();
//    }


//    internal IMongoCollection<SolicitudEntity> Solicitudes
//    {
//        get
//        {
//            return _database.GetCollection<SolicitudEntity>("Solicitudes");
//        }
//    }

//    internal IMongoCollection<CreditoEntity> creditos
//    {
//        get
//        {
//            return _database.GetCollection<CreditoEntity>("creditosusuarios");
//        }
//    }

//    internal IMongoCollection<UserEntity> users
//    {
//        get
//        {
//            return _database.GetCollection<UserEntity>("users");
//        }
//    }


//    //private void Map()
//    //{
//    //    BsonClassMap.RegisterClassMap<SolicitudEntity>(cm =>
//    //    {
//    //        cm.AutoMap();
//    //    });


//    //}
//}


//}