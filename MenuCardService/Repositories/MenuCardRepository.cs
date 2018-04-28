using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuCardService.Interfaces;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;

namespace MenuCardService.Repositories
{
    public interface IMenuCardRepository
    {
        Task<MenuData> AddMenuAsync(MenuData menuData);
        Task<MenuData> GetMenuAsync(int id);
    }

    public class MenuCardRepository : IMenuCardRepository
    {
        private readonly IReliableStateManager _stateManager;

        public MenuCardRepository(IReliableStateManager stateManager)
        {
            _stateManager = stateManager;
        }

        public async Task<MenuData> AddMenuAsync(MenuData menuData)
        {
            var dic = await this._stateManager.GetOrAddAsync<IReliableDictionary<int, MenuCardContract>>("Cards");
            using (var tx = this._stateManager.CreateTransaction())
            {
                await dic.AddAsync(tx, menuData.Id, new MenuCardContract()
                {
                    Id = menuData.Id,
                    Description = menuData.Description,
                    Name = menuData.Name
                });
                await tx.CommitAsync();
                return menuData;
            }
        }

        public async Task<MenuData> GetMenuAsync(int id)
        {
            var dic = await this._stateManager.GetOrAddAsync<IReliableDictionary<int, MenuCardContract>>("Cards");
            using (var tx = this._stateManager.CreateTransaction())
            {
                var val = await dic.TryGetValueAsync(tx, id);
                if (val.HasValue)
                {
                    var menuData = val.Value;
                    return new MenuData()
                    {
                        Id = menuData.Id,
                        Description = menuData.Description,
                        Name = menuData.Name
                    };
                }

                ;
                return null;
            }
        }
    }
}
