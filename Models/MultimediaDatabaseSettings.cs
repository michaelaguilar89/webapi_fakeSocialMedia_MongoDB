namespace WebApiMongoSaveImage.Models
{
	public class MultimediaDatabaseSettings
	{
		public string ConnectionString { get; set; }=null!;

		public string DatabaseName { get; set; } = null!;

		public string CollectionName { get; set; } = null!;
	}
}
