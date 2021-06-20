using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SimpleMongoAPI.Data;
using SimpleMongoAPI.Data.Collections;
using SimpleMongoAPI.Mappers;
using SimpleMongoAPI.Models;

namespace SimpleMongoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfectedController : ControllerBase
    {
        private readonly MongoDBContext _mongoDBContext;
        private readonly IMongoCollection<Infected> _infectedCollection;

        public InfectedController(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _infectedCollection = _mongoDBContext.Database.GetCollection<Infected>(typeof(Infected).Name.ToLower());
        }

        [HttpPost]
        public IActionResult SaveInfected([FromBody] InfectedDTO infectedDTO)
        {
            var infected = InfectedMapper.InfectedDtoToInfected(infectedDTO);

            _infectedCollection.InsertOne(infected);

            return Created("", infected);
        }

        [HttpGet]
        public IActionResult GetAllInfected()
        {
            var infectedList = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

            return Ok(infectedList);
        }
    }
}
