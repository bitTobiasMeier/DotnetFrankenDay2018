using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace MenuCardService.Interfaces
{
    public interface IMenuCardService : IService
    {
        Task<MenuData> AddMenuAsync(MenuData menuData);
        Task<MenuData> GetMenuAsync(int id);
    }
}