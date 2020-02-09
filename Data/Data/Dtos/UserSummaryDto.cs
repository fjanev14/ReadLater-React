using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadLater.Data.Dtos
{
    public class UserSummaryDto
    {
        public string UserName { get; set; }

        public int NumberOfClicks { get; set; }

        public int NumberOfBookmarks { get; set; }
    }
}
