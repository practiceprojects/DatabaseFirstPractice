using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseFirstPractice.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public virtual ICollection <Rentals> Rentals { get; set; }
    }
}