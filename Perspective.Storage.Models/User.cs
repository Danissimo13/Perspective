using System.Collections.Generic;

namespace Perspective.Storage.Models
{
    public class User
    {
        public long Id { get; init; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public IEnumerable<Objective> Objectives { get; set; }
    }
}
