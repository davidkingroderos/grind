﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Models
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int IsCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DeadlineDate { get; set; }

        [Ignore]
        public Color ThemeColor { get; set; }

        [Ignore]
        public string BoxIcon { get; set; }
    }
}
