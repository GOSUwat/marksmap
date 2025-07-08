using System.Security.Cryptography;
using WebApplication1;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/post/mark",(MarkerData markerData) =>
{
    markerData.marker_guid = Guid.NewGuid();
    Console.WriteLine(markerData.lat +" " + markerData.lng +" " + markerData.user_id + " " + markerData.descr + " " + markerData.marker_guid);
    using (DBProvider db = new DBProvider())
    {
        db.Markers.Add(markerData);
        db.SaveChanges();
    }
    return markerData.marker_guid;
});
app.MapGet("/api/get/marks", () =>
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
    
});


app.Run();



