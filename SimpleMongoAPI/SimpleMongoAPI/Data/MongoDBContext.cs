using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SimpleMongoAPI.Data.Collections;
using System;

namespace SimpleMongoAPI.Data
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; }

        public MongoDBContext(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration.GetConnectionString("DefaultConnection")));
                var client = new MongoClient(settings);    
                Database = client.GetDatabase(configuration["DatabaseName"]);

                MapClasses();
            }
            catch (Exception ex)
            {
                throw new MongoException("Não é possível se conectar ao MongoDB", ex);
            }
        }

        private void MapClasses()
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            if (!BsonClassMap.IsClassMapRegistered(typeof(Infected)))
            {
                BsonClassMap.RegisterClassMap<Infected>(i =>
                {
                    i.AutoMap();
                    i.SetIgnoreExtraElements(true);
                });
            }
        }
    }
}
