namespace Interfaces
{
    public interface IMapInterface
    {
        public Task<List<MarkerData>> GetMarksAsync();

        public Task<int> CreateMarkerAsync(MarkerData data);

        public Task<bool> DeleteMarkerAsync(int id);

        public Task<bool> UpdateMarkerAsync(int id, MarkerData data);
    }
}