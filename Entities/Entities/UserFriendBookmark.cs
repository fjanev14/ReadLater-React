using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Entities
{
    public class UserFriendBookmark : EntityBase
    {

        [Key]
        public int ID { get; set; }

        public int UserId { get; set; }

        public int? BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }

        public DateTime DateSend { get; set; }

        public string URL { get; set; }

        public List<int> FriendsIds { get; set; }
    }
}
