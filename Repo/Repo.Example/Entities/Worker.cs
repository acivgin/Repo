using System;

namespace Repo.Example.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public MartialStatus MartialStatus { get; set; }
        public Sex Sex { get; set; }
        public int YearlySalary { get; set; }
        public bool Active { get; set; }
        public virtual Company Company { get; set; }
    }
}