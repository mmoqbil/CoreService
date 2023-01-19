using CoreService_backend.Models;
namespace CoreService_backend.Dao
{
    public class UserDao
    {
        private List<User> data = new();
        public void Add(User user)
        {
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
                if (user.Name == login.Name && user.Password == login.Password)
                        {
                    return true;
                }
            }
            return false;
        }
        public void UpdateLogin(User user)
        {
            data.Find(x => x.Id == user.Id).Name = user.Name;
        }
        public void UpdatePassword(User user)
        {
            data.Find(x => x.Id == user.Id).Password = user.Password;
        }
    }
}
