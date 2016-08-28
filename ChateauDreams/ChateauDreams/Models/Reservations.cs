using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChateauDreams.Models
{
    public class Reservations
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser Guest { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Range(1, 20)]
        [Required]
        public int Persons { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Questions { get; set; }

    }
}