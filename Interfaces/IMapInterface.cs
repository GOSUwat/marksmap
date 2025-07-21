namespace Interfaces
{
    public interface IMapInterface
    {
        public Task<List<MarkerData>> GetMarksAsync();

        public Task<Guid> CreateMarkerAsync(MarkerData data);

        public Task<bool> DeleteMarkerAsync(Guid guid);

        public Task<bool> UpdateMarkerAsync(Guid guid, MarkerData data);
    }
}