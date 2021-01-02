using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class VideoGameModel
    {
        public int Id { get; set; }

        [Display(Name = "Game Title")]
        [Required(ErrorMessage = "You must enter a Game Title")]
        public string GameTitle { get; set; }

        [Display(Name = "Release Year")]
        public string ReleaseYear { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public bool CompleteCopy { get; set; }
        public bool PhysicalCopy { get; set; }
    }
}
