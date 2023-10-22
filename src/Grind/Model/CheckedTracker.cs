using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Model
{
    public class CheckedTracker
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        [Indexed]
        public int TrackerId { get; set; }
        public string Date { get; set; }
    }
}
