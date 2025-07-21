using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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