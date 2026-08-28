using Microsoft.AspNetCore.Mvc;
using GymTimeServer.Models;
using GymTimeServer.BusinessLogic;

namespace GymTimeServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private BookingBL bookingBL;

        public BookingsController(IConfiguration config)
        {
            bookingBL = new BookingBL(config);
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> GetMyBookings(int clientId)
        {
            List<Booking> list = await bookingBL.GetMyBookingsAsync(clientId);
            return Ok(list);
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetClassParticipants(int classId)
        {
            List<Booking> list = await bookingBL.GetClassParticipantsAsync(classId);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] Booking b)
        {
            ActionResultMsg result = await bookingBL.BookClassAsync(b.ClientID, b.ClassID);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        // שולחים גם clientId כדי שהשרת יוודא שזו ההזמנה שלו
        [HttpPut("{bookingId}/cancel")]
        public async Task<IActionResult> CancelMyBooking(int bookingId, [FromQuery] int clientId)
        {
            ActionResultMsg result = await bookingBL.CancelMyBookingAsync(clientId, bookingId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{bookingId}/status")]
        public async Task<IActionResult> ChangeStatus(int bookingId, [FromBody] string newStatus)
        {
            ActionResultMsg result = await bookingBL.ChangeStatusAsync(bookingId, newStatus);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
