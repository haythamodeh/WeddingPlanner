using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class LogRegWrapper
    {
        public User User { get; set; }
        public Login Login { get; set; }
    }
}