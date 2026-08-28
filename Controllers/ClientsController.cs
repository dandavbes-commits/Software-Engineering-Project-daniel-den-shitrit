using Microsoft.AspNetCore.Mvc;
using GymTimeServer.Models;
using GymTimeServer.BusinessLogic;

namespace GymTimeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private ClientBL clientBL;

        public ClientsController(IConfiguration config)
        {
            clientBL = new ClientBL(config);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            Client? c = await clientBL.LoginAsync(request);

            if (c == null)
            {
                return Unauthorized(new ActionResultMsg(false, "שם משתמש או סיסמה שגויים"));
            }

            return Ok(c);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Client newClient)
        {
            ActionResultMsg result = await clientBL.RegisterAsync(newClient);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Client> list = await clientBL.GetAllClientsAsync();
            return Ok(list);
        }
    }
}
