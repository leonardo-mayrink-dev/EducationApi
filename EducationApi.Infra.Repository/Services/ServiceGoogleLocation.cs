using System;
using EducationApi.Domain.Contracts.Services;
using GoogleMaps.LocationServices;

namespace EducationApi.Infra.Repository.Services
{
    public class ServiceGoogleLocation : ServiceBase, IServiceGoogleLocation
    {

        public string GetLocation()
        {
            var address = "Stavanger, Norway";

            var locationService = new GoogleLocationService();
            var point = locationService.GetLatLongFromAddress(address);

            var latitude = point.Latitude;
            var longitude = point.Longitude;

            return latitude.ToString();
        }
    }
}
