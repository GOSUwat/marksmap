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
            Console.WriteLine(data.lat + " " + data.lng + " " + data.user_id + " " + data.descr + " " + data.marker_guid);
            await _markers.AddValue(data);
            return data.marker_guid;
        }

        public Task<bool> DeleteMarkerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MarkerData>> GetMarksAsync()
        {
            return await _markers.GetList();
        }

        public Task<bool> UpdateMarkerAsync(int id, MarkerData data)
        {
            throw new NotImplementedException();
        }

        Task<int> IMapInterface.CreateMarkerAsync(MarkerData data)
        {
            throw new NotImplementedException();
        }
    }
}