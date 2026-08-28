using GymTimeServer.Models;
using GymTimeServer.ViewModels;

namespace GymTimeServer.BusinessLogic
{
    public class BookingBL
    {
        public const string STATUS_WAITING = "ממתין";
        public const string STATUS_APPROVED = "אושר";
        public const string STATUS_CANCELLED = "בוטל";

        private BookingVM bookingVM;
        private ClassVM classVM;

        public BookingBL(IConfiguration config)
        {
            bookingVM = new BookingVM(config);
            classVM = new ClassVM(config);
        }

        public async Task<List<Booking>> GetMyBookingsAsync(int clientId)
        {
            return await bookingVM.GetByClientAsync(clientId);
        }

        public async Task<List<Booking>> GetClassParticipantsAsync(int classId)
        {
            return await bookingVM.GetByClassAsync(classId);
        }

        public async Task<ActionResultMsg> BookClassAsync(int clientId, int classId)
        {
            GymClass? gc = await classVM.GetByIdAsync(classId);

            if (gc == null)
            {
                return new ActionResultMsg(false, "השיעור לא נמצא");
            }

            if (gc.IsCancelled)
            {
                return new ActionResultMsg(false, "השיעור בוטל, אי אפשר להירשם אליו");
            }

            DateTime classStart = gc.ClassDate.Date + gc.StartTime;
            if (classStart < DateTime.Now)
            {
                return new ActionResultMsg(false, "השיעור כבר התקיים");
            }

            if (await bookingVM.HasActiveBookingAsync(clientId, classId))
            {
                return new ActionResultMsg(false, "כבר נרשמת לשיעור הזה");
            }

            if (gc.FreePlaces <= 0)
            {
                return new ActionResultMsg(false, "השיעור מלא, לא נשארו מקומות");
            }

            Booking b = new Booking();
            b.ClientID = clientId;
            b.ClassID = classId;
            b.Status = STATUS_WAITING;

            int newId = await bookingVM.AddAsync(b);

            return newId > 0
                ? new ActionResultMsg(true, "ההזמנה נקלטה וממתינה לאישור המנהל")
                : new ActionResultMsg(false, "ההזמנה נכשלה, יש לנסות שוב");
        }

        public async Task<ActionResultMsg> CancelMyBookingAsync(int clientId, int bookingId)
        {
            Booking? b = await bookingVM.GetByIdAsync(bookingId);

            if (b == null)
            {
                return new ActionResultMsg(false, "ההזמנה לא נמצאה");
            }

            // אחרת אפשר היה לשלוח מספר הזמנה של מישהו אחר
            if (b.ClientID != clientId)
            {
                return new ActionResultMsg(false, "אין הרשאה לבטל את ההזמנה הזאת");
            }

            if (b.Status == STATUS_CANCELLED)
            {
                return new ActionResultMsg(false, "ההזמנה כבר מבוטלת");
            }

            DateTime classStart = b.ClassDate.Date + b.StartTime;
            if (classStart.AddHours(-2) < DateTime.Now)
            {
                return new ActionResultMsg(false,
                    "ביטול אפשרי עד שעתיים לפני תחילת השיעור");
            }

            bool ok = await bookingVM.UpdateStatusAsync(bookingId, STATUS_CANCELLED);
            return ok
                ? new ActionResultMsg(true, "ההזמנה בוטלה")
                : new ActionResultMsg(false, "הביטול נכשל");
        }

        public async Task<ActionResultMsg> ChangeStatusAsync(int bookingId, string newStatus)
        {
            if (newStatus != STATUS_WAITING &&
                newStatus != STATUS_APPROVED &&
                newStatus != STATUS_CANCELLED)
            {
                return new ActionResultMsg(false, "סטטוס לא חוקי");
            }

            Booking? b = await bookingVM.GetByIdAsync(bookingId);
            if (b == null)
            {
                return new ActionResultMsg(false, "ההזמנה לא נמצאה");
            }

            // אולי השיעור התמלא בינתיים
            if (newStatus != STATUS_CANCELLED && b.Status == STATUS_CANCELLED)
            {
                GymClass? gc = await classVM.GetByIdAsync(b.ClassID);
                if (gc != null && gc.FreePlaces <= 0)
                {
                    return new ActionResultMsg(false, "השיעור מלא, אי אפשר להחזיר את ההזמנה");
                }
            }

            bool ok = await bookingVM.UpdateStatusAsync(bookingId, newStatus);
            return ok
                ? new ActionResultMsg(true, "הסטטוס עודכן ל" + newStatus)
                : new ActionResultMsg(false, "העדכון נכשל");
        }
    }
}
