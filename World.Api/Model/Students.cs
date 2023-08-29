using System.ComponentModel.DataAnnotations;

namespace World.Api.Model
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string String { get; set; }

        public string phoneNumber { get; set; }


    }
}
