using System.Collections.Generic;

namespace Perspective.Storage.Models
{
    public class Tag
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Objective> Objectives { get; set; }
    }
}
