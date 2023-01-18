using CoreService_backend.Models;
namespace CoreService_backend.Dao
{
    public class ResourceDao
    {
        private List<Resource> data = new();
        public void Add(Resource resource)
        {
            data.Add(resource);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public Resource Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<Resource> GetAll()
        {
            return data;
        }
}
}
