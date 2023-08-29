using System.ComponentModel.DataAnnotations;

namespace World.Api.DTO.State
{
    public class CreateStateDto
    {
         public string Name { get; set; }

        public int Population { get; set; }

        public int CountryId { get; set; }
    }
}
