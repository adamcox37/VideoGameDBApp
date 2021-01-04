using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameCatolog.Models
{
    public class ConsoleModel
    {
        public int Id { get; set; }

        [Display(Name = "Console Name")]
        public string ConsoleName { get; set; }
        public string Manufacturer { get; set; }
        public string Notes { get; set; }
    }
}
