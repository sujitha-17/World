namespace World.Api.DTO.Country
{
    public class UpdateCountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string shortName { get; set; }

        public string CountryCode { get; set; }
    }
}
