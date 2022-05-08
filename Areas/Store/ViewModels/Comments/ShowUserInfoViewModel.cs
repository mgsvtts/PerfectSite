using PerfectSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectSite.Areas.Store.ViewModels.Comments
{
    public class ShowUserInfoViewModel
    {
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}