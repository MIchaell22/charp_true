using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace APIEnteety
{
    public class Flinghts
    {
        [Key]
        public int Flight_number { get; set; }
        public string Froms { get; set; }
        public string Wheres { get; set; }
        public string Airlines { get; set; }
        public int Length_km { get; set; }
        public string Time_in_path { get; set; }
        public string Aircraft_type { get; set; }

    }
}
