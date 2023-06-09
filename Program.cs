using WebApiMongoSaveImage.Models;
using WebApiMongoSaveImage.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
	options.AddPolicy(MyAllowSpecificOrigins,
						  policy =>
						  {
							  policy.WithOrigins("*")
												  .AllowAnyHeader()
												  .AllowAnyMethod();
						  });
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<MultimediaDatabaseSettings>(
	builder.Configuration.GetSection("MultimediaDatabase"));
builder.Services.AddSingleton<PostingService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
