using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PerfectSite.Areas.Account.ViewModels.Account;
using PerfectSite.Areas.Store.ViewModels.Comments;
using PerfectSite.Data.MongoDb;
using PerfectSite.Models;
using System.Data;
using System.Xml.Linq;

namespace PerfectSite.Areas.Store.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMongoCollection<Comment> _collection;
        private readonly UserManager<User> _userManager;

        public CommentController(IOptions<MongoOptions> mongoDBSettings, UserManager<User> userManager)
        {
            _userManager = userManager;
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<PartialViewResult> GetCommentsAsync(int productId)
        {
            var builder = new FilterDefinitionBuilder<Comment>();
            var filter = builder.Empty;

            filter &= builder.Eq("ProductId", productId);

            return PartialView("~/Areas/Store/Views/Comment/_GetComments.cshtml", await _collection.Find(filter).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comment comment, string pageUrl)
        {
            await _collection.InsertOneAsync(comment);
            if (!string.IsNullOrEmpty(pageUrl) && Url.IsLocalUrl(pageUrl))
            {
                return Redirect(pageUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ShowUserInfo(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            var comments = await _collection.Find(x => x.UserId == userId).ToListAsync();

            return base.View("~/Areas/Store/Views/Comment/ShowUserInfo.cshtml", new ShowUserInfoViewModel { User = user, Comments = comments });
        }

        [Authorize(Roles = "God of the Site")]
        public async Task<IActionResult> Delete(string commentId, string pageUrl)
        {
            await _collection.DeleteOneAsync(x => x.Id == commentId);

            if (!string.IsNullOrEmpty(pageUrl) && Url.IsLocalUrl(pageUrl))
            {
                return Redirect(pageUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}