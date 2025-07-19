using Interfaces;

namespace Services
{
    public class MapService : IMapInterface
    {
        private readonly NoDBMakerList _markers;
        public MapService(NoDBMakerList markers)
        {
            _markers = markers;
        }
        public async Task<Guid> CreateMarkerAsync(MarkerData data)
        {
            data.marker_guid = Guid.NewGuid();
            Console.WriteLine(data.marker_guid);
            await _markers.AddValue(data);
            return data.marker_guid;
        }

        public async Task<bool> DeleteMarkerAsync(Guid guid)
        {
            return await _markers.RemoveValue(guid);
        }

        public async Task<List<MarkerData>> GetMarksAsync()
        {
            return await _markers.GetList();
        }

        public Task<bool> UpdateMarkerAsync(int id, MarkerData data)
        {
            throw new NotImplementedException();
        }
    }
}