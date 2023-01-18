namespace CoreService_backend.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IpAdress { get; set; }
        public int UserId { get; set; }
        private static int _nextId = 0;
        public Resource(string name, string ipAdress, int userId)
        {
            Name = name;
            IpAdress = ipAdress;
            UserId = userId;
            Id = Interlocked.Increment(ref _nextId);
        }
    }
}
