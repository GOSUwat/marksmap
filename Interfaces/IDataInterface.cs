namespace Interfaces
{
    public interface IDataInterface<T,G> where G : notnull
    {
        public Task AddValue(T data);

        public Task<bool> RemoveValue(G guid);

        public Task<Dictionary<G,T>> GetValues();

        public Task<MarkerData>? GetValue(G guid);

        public Task<bool> UpdateValue(T data);
    }
}