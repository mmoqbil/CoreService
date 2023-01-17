using CoreService_backend.Models;
namespace CoreService_backend.Dao
{
    public class UserDao
    {
        private List<User> data = new();
        public void Add(User user)
        {
            user.Id = data.Count + 1;
            data.Add(user);
        }

        public void Remove(int id)
        {
            data.Remove(Get(id));
        }

        public User Get(int id)
        {
            return data.Find(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return data;
        }
        public bool CheckLogin(User login)
        {
            foreach (var user in data)
            {
                if (user.name == login.name && user.password == login.password)
                        {
                    return true;
                }
            }
            return false;
        }
    }
}
