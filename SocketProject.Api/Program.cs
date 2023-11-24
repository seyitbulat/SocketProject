using SocketProject.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.WithOrigins("https://localhost:7121")
						.AllowAnyHeader()
						.WithMethods("GET", "POST")
						.AllowCredentials();
	});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();


app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
