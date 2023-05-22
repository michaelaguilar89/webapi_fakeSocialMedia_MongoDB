using Microsoft.Extensions.Options;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Reflection.Metadata.Ecma335;
using WebApiMongoSaveImage.Models;

namespace WebApiMongoSaveImage.Services
{
	public class PostingService
	{
		private readonly IMongoCollection<Post> _postCollection;

		public PostingService(
			IOptions<MultimediaDatabaseSettings> multimediaDatabaseSettings
			)
		{
			var mongoClient = new MongoClient(
				multimediaDatabaseSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(
				multimediaDatabaseSettings.Value.DatabaseName);
			_postCollection = mongoDatabase.GetCollection<Post>(
				multimediaDatabaseSettings.Value.CollectionName);
		
		}

		public async Task<List<Post>> GetAsync()
		{
		 return	await _postCollection.Find(_ => true).ToListAsync();
		}
		public async Task<Post?> GetAsyncId(string id)
		{
			return await _postCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
		}
		public async Task<string> CreateAsync(Post post)
		{
			
				await _postCollection.InsertOneAsync(post);
				return "Insert Ok";
			
			
		}

		public async Task<string> UpdateAsync(string id, Post postUpdate)
		{
			
				await _postCollection.ReplaceOneAsync(x => x.Id == id, postUpdate);
				return "Update Ok";
			
		}
		public async Task<string> RemoveAsync(string id)
		{
			
				await _postCollection.DeleteOneAsync(x => x.Id == id);
				return "Remove Ok";
			
		}
	}
}
