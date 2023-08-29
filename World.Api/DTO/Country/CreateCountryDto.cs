using System.ComponentModel.DataAnnotations;

namespace World.Api.DTO.Country
{
    public class CreateCountryDto
    {
        public string Name { get; set; }
        public string shortName { get; set; }

        public string CountryCode { get; set; }
    }
}
