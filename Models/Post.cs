using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMongoSaveImage.Models
{
	public class Post
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		public string Messsage { get; set; }=null!;

        public string Url { get; set; } = null!;

		// public string UserId { get; set; }

		public string UserName { get; set; } = null!;

	}
}
