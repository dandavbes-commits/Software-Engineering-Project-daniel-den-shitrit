using Microsoft.AspNetCore.Mvc;
using GymTimeServer.Models;
using GymTimeServer.BusinessLogic;

namespace GymTimeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassTypesController : ControllerBase
    {
        private ClassBL classBL;

        public ClassTypesController(IConfiguration config)
        {
            classBL = new ClassBL(config);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ClassType> list = await classBL.GetAllTypesAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClassType t)
        {
            ActionResultMsg result = await classBL.AddTypeAsync(t);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClassType t)
        {
            t.TypeID = id;
            ActionResultMsg result = await classBL.UpdateTypeAsync(t);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ActionResultMsg result = await classBL.DeleteTypeAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
