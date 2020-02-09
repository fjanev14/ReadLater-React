using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Data.Dtos
{
    public class AddUserBookmark
    {
        public Guid UserId { get; set; }
        public int BookmarkId { get; set; }
    }
}
