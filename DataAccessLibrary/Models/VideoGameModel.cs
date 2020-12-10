using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
    public class VideoGameModel
    {
        public int Id { get; set; }
        public string GameTitle { get; set; }
        public int ReleaseYear { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public bool CompleteCopy { get; set; }
        public bool PhysicalCopy { get; set; }
    }
}
