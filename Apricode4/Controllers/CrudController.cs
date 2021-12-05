using Apricode4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apricode4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrudController : ControllerBase
    {
        private GameRepository gameRepository = new GameRepository();

        [HttpPost("CreateOrUpdate")]
        public async Task CreateOrUpdateAsync(GameModel gameModel)
        {
            await gameRepository.CreateOrUpdateAsync(gameModel);
        }

        [HttpGet("Read")]
        public async Task<List<GameModel>> ReadAsync(string gameName)
        {
           return await gameRepository.ReadAsync(gameName);
        }

        [HttpPost("Del")]
        public async Task DelAsync(string gameName, string studioDeveloper)
        {
            await gameRepository.DelAsync(gameName, studioDeveloper);
        }


    }
}
