using Interfaces;
using Services;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddSingleton<NoDBMakerList>();
builder.Services.AddScoped<IMapInterface, MapService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseRouting();
app.MapControllers();

app.UseDefaultFiles();
app.UseStaticFiles();

/*app.MapGet("/api/get/marks", () =>
{
    using (DBProvider db = new DBProvider())
    {
        return db.Markers.ToList();
    }
});

app.MapDelete("/api/marks/{guid}", (Guid guid) =>
{
    using (DBProvider db = new DBProvider())
    {
        var marker = db.Markers.First(x => x.marker_guid == guid);
        if (marker == null)
        {
            return Results.NotFound();
        }
        db.Markers.Remove(marker);
        db.SaveChanges();
    }
    return Results.Accepted();
});


app.Map("/delete", () =>
{
    Console.WriteLine("zaprosudal");
    using (DBProvider db = new DBProvider())
    {
        foreach (MarkerData md in db.Markers.ToList())
        {
            db.Markers.Remove(md);
        }
        db.SaveChanges();
    }
    return Results.Accepted();
    
});*/


app.Run();



