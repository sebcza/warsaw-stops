using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using warsaw_stops_data.Models;

namespace warsaw_stops_data
{
    public class WarsawStopsContext : DbContext
    {
        public DbSet<Stop> Stops { get; set; }
    }
}
