using System;
using System.Threading.Tasks;
using MenuCardService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Client;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace GatewayService.Controllers
{
    [Route("api/[controller]")]
    public class MenuCardController : Controller
    {
        [HttpGet("{id}")]
        public async Task<MenuData> Get(int id)
        {
            var proxy = this.CreateProxy();
            return await proxy.GetMenuAsync(id);
        }
        
        [HttpPost]
        public async Task<MenuData> Post([FromBody]MenuData value)
        {
            var proxy = this.CreateProxy();
            return await proxy.AddMenuAsync(value);
        }

        private IMenuCardService CreateProxy()
        {
            return ServiceProxy.Create<IMenuCardService>(new Uri("fabric:/NetFrankenDay2018/MenuCardService"),
                new ServicePartitionKey(0));
        }
    }
}