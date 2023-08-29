﻿using System.ComponentModel.DataAnnotations;

namespace World.Api.Model
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(5)]
        public string shortName { get; set; }

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; }

    }
}
