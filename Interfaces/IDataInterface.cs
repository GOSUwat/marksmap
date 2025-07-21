namespace Interfaces
{
    public interface IDataInterface<T,G>
    {
        public Task AddValue(T data);

        public Task<bool> RemoveValue(G guid);

        public Task<List<T>> GetValuesList();

        public Task<T> GetValue(G guid);

        public Task<bool> UpdateValue(T data);
    }
}