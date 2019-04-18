using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID { get; set; }

        [Required(ErrorMessage = "Input cannot be blank")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "Input cannot be blank")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "Input cannot be blank")]
        public DateTime Date {get; set;}

        [Required(ErrorMessage = "Input cannot be blank")]
        public string Address {get; set;}

        public int UserID { get; set; }

        public List<Association> AllGuests {get; set;}

        
        [Required]
        public DateTime Created_At {get; set;} = DateTime.Now;
        [Required]
        public DateTime Updated_At {get; set;} = DateTime.Now;
    }
}