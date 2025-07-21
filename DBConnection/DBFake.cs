using Interfaces;

namespace DBConnection
{
    public class DBFake:IDataInterface<MarkerData,Guid>
    {
        public List<MarkerData> markers = new List<MarkerData>();

        public async Task AddValue(MarkerData data)
        {
            await Task.Delay(0);
        }

        public async Task<MarkerData> GetValue(Guid guid)
        {
            await Task.Delay(0);
        }

        public async Task<List<MarkerData>> GetValuesList()
        {
            await Task.Delay(0);
        }

        public async Task<bool> UpdateValue(MarkerData data)
        {
            await Task.Delay(0);
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
}