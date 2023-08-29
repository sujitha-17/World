namespace World.Api.DTO.State
{
    public class UpdateStateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public int CountryId { get; set; }
    }
}
