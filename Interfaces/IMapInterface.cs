namespace Interfaces
{
    public interface IMapInterface<T,G> where G : notnull
    {
        public Task<Dictionary<G,T>> GetMarksAsync();

        public Task<G> CreateMarkerAsync(T data);

        public Task<bool> DeleteMarkerAsync(G guid);

        public Task<bool> UpdateMarkerAsync(T data);
    }
}