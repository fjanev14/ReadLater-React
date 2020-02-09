using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Entities
{
    public class UserFriendBookmark1 : EntityBase
    {

        [Key]
        public Guid ID { get; set; }

        public Guid UserId { get; set; }

        public int? BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }

        public DateTime DateSend { get; set; }

        public string URL { get; set; }

        public List<Guid> FriendsIds { get; set; }
    }
}
