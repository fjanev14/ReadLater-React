using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Data.Dtos
{
    public class UserFriendDto
    {
        public Guid UserId { get; set; }
        public string ShortUrl { get; set; }
        public int BookmarkId { get; set; }
        public List<Guid> FriendId { get; set; }
    }
}
