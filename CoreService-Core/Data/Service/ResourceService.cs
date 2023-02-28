using CoreService_Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CoreService_Core.Data.Service
{
    public class ResourceService
    {
        public IEnumerable<Resource> resources;

        public ResourceService()
        {
            var list = new Queue();
            resources = list._repository;
        }
       public string GetResourceIPById(int id)
        {
            foreach (var resource in resources)
            {
                if (id == resource.Id)
                {
                    return resource.IpAdress;
                }
            }
             return null;
        }
    }
}
