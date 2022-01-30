using System;
using System.Collections.Generic;

namespace Perspective.Storage.Models
{
    public class Objective
    {
        public long Id { get; init; }

        public long Number { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string WebReference { get; set; }

        public decimal? Cost { get; set; }

        public decimal Progress { get; set; }

        public DateTime Deadline { get; set; }

        public User Owner { get; set; }
        public long OwnerId { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
