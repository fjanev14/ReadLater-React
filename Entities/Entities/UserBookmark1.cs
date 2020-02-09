using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Entities
{
   public class UserBookmark1:EntityBase
    {
        [Key]
        public Guid ID { get; set; }

        public Guid UserId { get; set; }

        public int? BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }

        public int NumberOfClicks { get; set; }

        public DateTime DateClicked { get; set; }
    }
}
