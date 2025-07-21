using Interfaces;

namespace DBConnection
{
    public class DBFake:IDataInterface<MarkerData,Guid>
    {
        private Dictionary<Guid,MarkerData> _md = new Dictionary<Guid,MarkerData>();

        public async Task AddValue(MarkerData data)
        {
            await Task.Delay(0);
            _md[data.marker_guid] = data;
        }
        public async Task<MarkerData> GetValue(Guid guid)
        {
            await Task.Delay(0);
            MarkerData data;
            _md.TryGetValue(guid, out data);
            return data;
        }

        public async Task<Dictionary<Guid,MarkerData>> GetValues()
        {
            await Task.Delay(0);
            return _md;
        }

        public async Task<bool> UpdateValue(MarkerData data)
        {
            await Task.Delay(0);
            if (_md.ContainsKey(data.marker_guid))
            {
                _md[data.marker_guid] = data;
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveValue(Guid guid)
        {
            await Task.Delay(0);
            return _md.Remove(guid);
        }

        
    }
}