using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Data.Dtos
{
    public class UserBookmarkDto
    {
        public Guid ID { get; set; }

        public Guid UserId { get; set; }
        public int BookmarkId { get; set; }
        public string BookmarkName { get; set; }
        public string BookmarkUrl { get; set; }
        public string CategoryName { get; set; }
        public int NumberOfClicks { get; set; }

        public DateTime DateClicked { get; set; }
    }
}
