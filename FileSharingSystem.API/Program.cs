using FileSharingSystem.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
	options.AddPolicy("AllowLocalhost",
		policy =>
		{
			policy.WithOrigins("*")
			.WithMethods("GET", "POST", "DELETE", "PUT", "OPTIONS").AllowAnyHeader();
		});
});

builder.Services.ConfigureServices(builder.Configuration);
builder.Services.ConfigureLogging(builder);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
