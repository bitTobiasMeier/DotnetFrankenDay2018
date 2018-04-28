using System.Threading.Tasks;
using MenuCardService.Interfaces;
using MenuCardService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuCardService.Controllers
{
    [Route("api/[controller]")]
    public class MenuCardController : Controller
    {
        private readonly IMenuCardRepository _menuCardRepository;


        public MenuCardController(IMenuCardRepository menuCardRepository)
        {
            _menuCardRepository = menuCardRepository;
        }

        [HttpGet("{id}")]
        public async Task<MenuData> Get(int id)
        {
            return await this._menuCardRepository.GetMenuAsync(id);
        }

        [HttpPost]
        public async Task<MenuData> Post([FromBody] MenuData value)
        {
            return await _menuCardRepository.AddMenuAsync(value);
        }
    }
}