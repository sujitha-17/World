using System.ComponentModel.DataAnnotations;

namespace World.Api.Model
{
    public class State
    {
        [Key]
        public int Id {  get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }


    }
}
