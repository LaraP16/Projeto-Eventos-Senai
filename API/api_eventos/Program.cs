var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
<<<<<<< HEAD
 
=======

>>>>>>> 9d9729f5f3520e03ed5d70582011149b0179b639
var app = builder.Build();
 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
<<<<<<< HEAD
 
=======

>>>>>>> 9d9729f5f3520e03ed5d70582011149b0179b639
app.Run();
