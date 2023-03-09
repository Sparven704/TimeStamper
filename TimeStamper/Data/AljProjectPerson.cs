using System;
using System.Collections.Generic;

namespace TimeStamper.Data
{
    public partial class AljProjectPerson
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }
        public int Hours { get; set; }

        public virtual AljPerson Person { get; set; } = null!;
        public virtual AljProject Project { get; set; } = null!;
    }
}
