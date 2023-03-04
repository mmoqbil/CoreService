using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service.Interface;

public interface IResourceRepository
{
    public Task<IEnumerable<Resource>?> GetAllResourceAsync();

}