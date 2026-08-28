using Microsoft.AspNetCore.Mvc;
using GymTimeServer.Models;
using GymTimeServer.BusinessLogic;

namespace GymTimeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private ClassBL classBL;

        public ClassesController(IConfiguration config)
        {
            classBL = new ClassBL(config);
        }

        [HttpGet("schedule")]
        public async Task<IActionResult> GetSchedule()
        {
            List<GymClass> list = await classBL.GetScheduleForClientAsync();
            return Ok(list);
        }

        [HttpGet("manager")]
        public async Task<IActionResult> GetManagerSchedule([FromQuery] DateTime? fromDate)
        {
            DateTime from = fromDate ?? DateTime.Today;
            List<GymClass> list = await classBL.GetScheduleForManagerAsync(from);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GymClass gc)
        {
            ActionResultMsg result = await classBL.AddClassAsync(gc);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] GymClass gc)
        {
            gc.ClassID = id;
            ActionResultMsg result = await classBL.UpdateClassAsync(gc);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        // PUT ולא DELETE כי השורה לא באמת נמחקת
        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            ActionResultMsg result = await classBL.CancelClassAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
