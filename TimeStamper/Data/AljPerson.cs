using System;
using System.Collections.Generic;

namespace TimeStamper.Data
{
    public partial class AljPerson
    {
        public AljPerson()
        {
            AljProjectPeople = new HashSet<AljProjectPerson>();
        }

        public int Id { get; set; }
        public string PersonName { get; set; } = null!;

        public virtual ICollection<AljProjectPerson> AljProjectPeople { get; set; }
    }
}
