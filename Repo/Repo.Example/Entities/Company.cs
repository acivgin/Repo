using System.Collections.Generic;

namespace Repo.Example.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
    }
}