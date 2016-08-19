using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChateauDreams.Models
{
    public class ReviewModels
   
    {
        public ReviewModels()
        {
            
            this.Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        

        [Required]
        public string Likes { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}