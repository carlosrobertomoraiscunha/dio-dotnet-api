using MongoDB.Driver.GeoJsonObjectModel;
using System;

namespace SimpleMongoAPI.Data.Collections
{
    public class Infected
    {
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates Coordinates { get; set; }

        public Infected(DateTime birthDate, string gender, GeoJson2DGeographicCoordinates coordinates)
        {
            BirthDate = birthDate;
            Gender = gender;
            Coordinates = coordinates;
        }
    }
}
