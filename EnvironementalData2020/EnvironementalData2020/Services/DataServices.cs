using EnvironementalData2020.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnvironementalData2020.Services
{
    public class DataServices
    {
        private readonly IMongoCollection<EnvironementalData> _data;

        public DataServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _data = database.GetCollection<EnvironementalData>(settings.CollectionName);
        }

        public List<EnvironementalData> Get() =>
            _data.Find(book => true).ToList();

        public EnvironementalData Get(string id) =>
            _data.Find<EnvironementalData>(data => data.Id == id).FirstOrDefault();

        public EnvironementalData Create(EnvironementalData data)
        {
            _data.InsertOne(data);
            return data;
        }

        public void Update(string id, EnvironementalData dataIn) =>
            _data.ReplaceOne(data => data.Id == id, dataIn);

        public void Remove(EnvironementalData dataIn) =>
            _data.DeleteOne(book => book.Id == dataIn.Id);

        public void Remove(string id) =>
            _data.DeleteOne(data => data.Id == id);
    }
}
    
