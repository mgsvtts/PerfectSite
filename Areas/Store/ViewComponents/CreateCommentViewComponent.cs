using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PerfectSite.Data.MongoDb;
using PerfectSite.Models;

namespace PerfectSite.ViewComponents
{
    public class CreateCommentViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        private readonly IMongoCollection<Comment> _collection;

        public CreateCommentViewComponent(UserManager<User> userManager, IOptions<MongoOptions> mongoDBSettings)
        {
            _userManager = userManager;

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId, string userId, string productName)
        {
            User user = await _userManager.FindByIdAsync(userId);

            Comment comment = new Comment
            {
                UserId = user.Id,
                UserFirstName = user.FirstName,
                UserSecondName = user.SecondName,
                ProductId = productId,
                ProductName = productName,
                CreatedDate = DateTime.Now,
            };

            return await Task.FromResult(View("~/Areas/Store/Views/Comment/_Create.cshtml", comment));
        }
    }
}