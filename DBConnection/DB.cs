using Interfaces;

namespace DBConnection
{
    public class DB : IDataInterface<MarkerData, Guid>
    {
        public Task AddValue(MarkerData data)
        {
            throw new NotImplementedException();
        }

        public Task<MarkerData> GetValue(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<List<MarkerData>> GetValuesList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveValue(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateValue(MarkerData data)
        {
            throw new NotImplementedException();
        }
    }
}