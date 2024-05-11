using MangedIdentityApi;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Ver ConnectionString en el appsettings.json

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();


app.MapGet("/products", async (AppDbContext context) =>
{
	try
	{
        var products = await context.Products.ToListAsync();

        return Results.Ok(products);
    }
	catch (Exception ex)
	{
       return Results.Text(ex.ToString(), statusCode: 500);
	}

    
})
.WithName("GetProducts")
.WithOpenApi();

app.Run();

