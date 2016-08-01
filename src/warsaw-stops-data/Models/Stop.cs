using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace warsaw_stops_data.Models
{
    public class Stop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Direction { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
