using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Data.Model;

namespace CoreService_Core.Data
{
    internal class Queue
    {
        public IEnumerable<Resource> _repository;
        public List<Class1> Queue;



        public Queue()
        {
            _repository = new List<Resource>()
            {
                new Resource()
                {
                    Id = 1,
                    IpAdress = "http://www.iamtimcorey.com",
                    Name = "IamTimCorey",
                    Repeat = TimeSpan.FromMinutes(30),
                    UserId = "1",
                },
                new Resource()
                {
                    Id = 2,
                    IpAdress = "https://codecool.com/pl/o-nas/",
                    Name = "CC/about",
                    Repeat = TimeSpan.FromMinutes(30),
                    UserId = "2",
                },
                new Resource()
                {
                    Id = 2,
                    IpAdress = "https://codecool.com/pl",
                    Name = "CC/home",
                    Repeat = TimeSpan.FromMinutes(30),
                    UserId = "2",
                }
            };
        }
    }
}
