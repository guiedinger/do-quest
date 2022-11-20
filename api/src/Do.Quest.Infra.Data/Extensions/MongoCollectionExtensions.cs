using MongoDB.Driver;
using System.Linq.Expressions;

namespace Do.Quest.Infra.Data.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static async Task<TDocument> FirstOrDefaultAsync<TDocument>(this IMongoCollection<TDocument> collection, 
                                                                Expression<Func<TDocument, bool>> filter)
        {
            return await (await collection.FindAsync(filter)).FirstOrDefaultAsync();
        }

        public static async Task<ICollection<TDocument>> ToListAsync<TDocument>(this IMongoCollection<TDocument> collection)
        {
            return await collection.ToListAsync(c => true);
        }

        public static async Task<ICollection<TDocument>> ToListAsync<TDocument>(this IMongoCollection<TDocument> collection, 
                                                                                Expression<Func<TDocument, bool>> filter)
        {
            return await (await collection.FindAsync(filter)).ToListAsync();
        }
    }
}
