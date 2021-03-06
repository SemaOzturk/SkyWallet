﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SkyWallet.Dal.IRepositories
{
    public class MongoRepository<TDocument> :IMongoRepository<TDocument> where TDocument :IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoDbSettings settings)
        {
            var replace = settings.ConnectionString.Replace("<password>", settings.Pass)
                .Replace("<dbname>", settings.DatabaseName);

            var database=new MongoClient(replace).GetDatabase(settings.DatabaseName);
            var servers = new List<MongoServerAddress>() { new MongoServerAddress(replace) };
            var credential = MongoCredential.CreateCredential(settings.DatabaseName, settings.User, settings.Pass);
            var mongoClientSettings = new MongoClientSettings()
            {
                ConnectionMode = ConnectionMode.Direct,
                Credential = credential,
                Servers = servers.ToArray()
              //  ApplicationName = "NameOfApp",
            };
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));

        }

        private string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }
        public IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public TDocument GetByKey(string id)
        {
            var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, objectId);
            return _collection.Find(filter).SingleOrDefault();
        }

        public void Insert(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
        }
        
        public IQueryable<TDocument> GetAll()
        {
            return _collection.AsQueryable();
        }

        public void Update(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
        }

        public void Delete(string id)
        {
            var objectId=new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id,objectId);
            _collection.FindOneAndDelete(filter);
        }

        public IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }
    }
}