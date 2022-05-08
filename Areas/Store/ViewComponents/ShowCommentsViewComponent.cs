using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PerfectSite.Data.MongoDb;
using PerfectSite.Models;

namespace PerfectSite.ViewComponents
{
    public class ShowCommentsViewComponent : ViewComponent
    {
        private readonly IMongoCollection<Comment> _collection;

        public ShowCommentsViewComponent(IOptions<MongoOptions> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _collection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId, string pageUrl)
        {
            var builder = new FilterDefinitionBuilder<Comment>();
            var filter = builder.Empty;

            filter = filter & builder.Eq("ProductId", productId);

            List<Comment> comments = await _collection.Find(filter).SortByDescending(x => x.CreatedDate).ToListAsync();

            return await Task.FromResult(View("~/Areas/Store/Views/Comment/_GetComments.cshtml", new GetCommentsModel { Comments = comments, PageUrl = pageUrl }));
        }
    }
}