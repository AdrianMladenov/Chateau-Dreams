using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChateauDreams.Models.Hotel
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}