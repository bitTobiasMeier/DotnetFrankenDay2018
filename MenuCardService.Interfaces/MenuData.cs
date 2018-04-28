using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace MenuCardService.Interfaces
{
    public interface IMenuCardService : IService
    {
        Task<MenuData> AddMenuAsync(MenuData menuData);
        Task<MenuData> GetMenuAsync(int id);
    }

    public class MenuData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
