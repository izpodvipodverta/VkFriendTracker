using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class FriendEntry : Entity
    {
        public DateTime AddDate { get; set; }
        public string ProfileId { get; set; }
        public bool IsDeleted { get; set; }
        public Male Male { get; set; }
        public int UserId { get; set; }
        public virtual ObservedUser User { get; set; }
        public string ProfileLink => "vk.com/" + ProfileId;
    }

    public enum Male
    {
        Man,
        Woman
    }
}
