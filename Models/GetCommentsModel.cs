using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSite.Models
{
    public class GetCommentsModel
    {
        public List<Comment> Comments { get; set; }
        public string PageUrl { get; set; }
    }
}