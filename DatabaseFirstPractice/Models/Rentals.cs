using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseFirstPractice.Models
{
    public class Rentals
    {
        [Key]
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("Movies")]
        public int MovieId { get; set; }
        public virtual Movies Movies { get; set; }

    }
}