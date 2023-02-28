using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Data
{
    internal class Queue
    {
        public IEnumerable<Resource> _repository;

        public Queue()
        {
            _repository = new List<Resource>()
            {
               new Resource()
                {
                    Id = 1,
                    IpAdress = "http://www.iamtimcorey.com",
                    Name = "IamTimCorey",
                    RepeatSeconds = 180,
                    UserId = "1",
                    TimeLeftSeconds = 180,
                },
                new Resource()
                {
                    Id = 2,
                    IpAdress = "https://codecool.com/pl/o-nas/",
                    Name = "CC/about",
                    RepeatSeconds = 60,
                    UserId = "2",
                    TimeLeftSeconds = 60,
                },
                new Resource()
                {
                    Id = 2,
                    IpAdress = "https://codecool.com/pl",
                    Name = "CC/home",
                    RepeatSeconds = 120,
                    UserId = "2",
                    TimeLeftSeconds= 120,
                }
            };
        }
    }
}
