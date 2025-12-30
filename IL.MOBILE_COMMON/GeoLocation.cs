using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RN.MOBILE_COMMON
{
    public class GeoLocation:ICloneable
    {
        public int LOC_ID { get; set; }
        public string LOC_NAME { get; set; }
        public string LOC_ADDRESS { get; set; }
        public decimal DISCOUNT { get; set; }
        public double GEO_LATITUDE { get; set; }
        public double GEO_LONGITUDE { get; set; }
        public double GEO_DISTANCE { get; set; }
        public string SEARCH_TYPE { get; set; }
        public string CITY { get; set; }
        public int CITY_ID { get; set; }
        public int SpecialityId { get; set; }
        public string PinCode { get; set; }
        public int userId { get; set; }
        public string EntityCode { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    // Calculate distance
    //var distance = new Coordinates(frm_lat, frm_long).DistanceTo(new Coordinates(to_lat, to_long), UnitOfLength.Kilometers);

    public class Coordinates
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
    public static class CoordinatesDistanceExtensions
    {
        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates)
        {
            return DistanceTo(baseCoordinates, targetCoordinates, UnitOfLength.Kilometers);
        }

        public static double DistanceTo(this Coordinates baseCoordinates, Coordinates targetCoordinates, UnitOfLength unitOfLength)
        {
            var baseRad = Math.PI * baseCoordinates.Latitude / 180;
            var targetRad = Math.PI * targetCoordinates.Latitude / 180;
            var theta = baseCoordinates.Longitude - targetCoordinates.Longitude;
            var thetaRad = Math.PI * theta / 180;

            double dist =
                Math.Sin(baseRad) * Math.Sin(targetRad) + Math.Cos(baseRad) *
                Math.Cos(targetRad) * Math.Cos(thetaRad);
            dist = Math.Acos(dist);

            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return unitOfLength.ConvertFromMiles(dist);
        }
    }

    public class UnitOfLength
    {
        public static UnitOfLength Kilometers = new UnitOfLength(1.609344);
        public static UnitOfLength NauticalMiles = new UnitOfLength(0.8684);
        public static UnitOfLength Miles = new UnitOfLength(1);

        private readonly double _fromMilesFactor;

        private UnitOfLength(double fromMilesFactor)
        {
            _fromMilesFactor = fromMilesFactor;
        }

        public double ConvertFromMiles(double input)
        {
            return input * _fromMilesFactor;
        }
    }
}
