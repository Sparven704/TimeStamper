using System;
using System.Collections.Generic;

namespace TimeStamper.Data
{
    public partial class AljProject
    {
        public AljProject()
        {
            AljProjectPeople = new HashSet<AljProjectPerson>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;

        public virtual ICollection<AljProjectPerson> AljProjectPeople { get; set; }
    }
}
