using Microsoft.AspNetCore.Mvc;
using PerfectSite.Models;

namespace PerfectSite.Areas.Account.ViewModels.Cabinet
{
    public class MainViewModel
    {
        public User User { get; set; }
        public string? ReturnUrl { get; set; }
    }
}