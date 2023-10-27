﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }

        [DisplayName("Villa Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        public string? Description { get; set; }
        [DisplayName("Price per night")]
        [Range(10, 100000)]
        public double Price { get; set; }
        public int Sqft { get; set; }
        [Range(1,10)]
        public int Occupancy { get; set; }
        [DisplayName("Image Url")]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Updated_Date { get;set; }
    }
}
