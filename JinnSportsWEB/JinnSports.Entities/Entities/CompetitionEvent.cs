﻿using System;
using System.Collections.Generic;

namespace JinnSports.Entities
{
    public class CompetitionEvent
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
