using System.Collections.Generic;

namespace Domain.Entities
{
    public class ObservedUser : Entity
    {
        public string ProfileId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<FriendEntry> FriendEntries { get; set; } = new List<FriendEntry>();
    }
}
