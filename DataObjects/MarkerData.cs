using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class NoDBMakerList
{
    public List<MarkerData> markers = new List<MarkerData>();

    public async Task AddValue(MarkerData data)
    {
        markers.Add(data);
        await Task.Delay(0);
    }

    public async Task<List<MarkerData>> GetList()
    {
        await Task.Delay(0);
        return markers;
    }

    public async Task<bool> RemoveValue(Guid guid)
    {
        await Task.Delay(0);
        MarkerData? removedMarker = markers.FirstOrDefault(x => x.marker_guid == guid);
        if (removedMarker != null)
        {
            markers.Remove(removedMarker);
            return true;
        }
        return false;
    } 
}

[Table("markers")]
public class MarkerData
{
    [Key]
    public Guid marker_guid { get; set; }
    public double lat { get; set; }
    public double lng { get; set; }
    public string? descr { get; set; }
    public int user_id { get; set; }

}