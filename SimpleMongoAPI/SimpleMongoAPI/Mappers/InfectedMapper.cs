using MongoDB.Driver.GeoJsonObjectModel;
using SimpleMongoAPI.Data.Collections;
using SimpleMongoAPI.Models;

namespace SimpleMongoAPI.Mappers
{
    public static class InfectedMapper
    {
        public static Infected InfectedDtoToInfected(InfectedDTO infectedDTO)
        {
            return new Infected(birthDate: infectedDTO.BirthDate,
                                gender: infectedDTO.Gender,
                                coordinates: new GeoJson2DGeographicCoordinates(longitude: infectedDTO.Longitude,
                                                                                latitude: infectedDTO.Latitude));
        }

        public static InfectedDTO InfectedToInfectedDTIO(Infected infected)
        {
            return new InfectedDTO {
                BirthDate = infected.BirthDate,
                Gender = infected.Gender,
                Latitude = infected.Coordinates.Latitude,
                Longitude = infected.Coordinates.Longitude
            };
        }
    }
}
