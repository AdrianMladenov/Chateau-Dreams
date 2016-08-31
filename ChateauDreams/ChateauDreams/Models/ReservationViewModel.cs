using ChateauDreams.Models.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChateauDreams.Models
{
    public class ReservationViewModel
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser Guest { get; set; }
        
        [Required]
        [Display(Name = "Room Type")]
        public IEnumerable<SelectListItem> RoomType { get; set; }

        [Required]
        public string Type { get; set; }

        [Range(1, 20)]
        [Required]
        public int Persons { get; set; }

        [Required]
        [Display(Name = "Check in")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Display(Name = "Check out")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Questions { get; set; }



    }
}