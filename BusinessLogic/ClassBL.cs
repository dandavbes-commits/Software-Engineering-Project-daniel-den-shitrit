using GymTimeServer.Models;
using GymTimeServer.ViewModels;

namespace GymTimeServer.BusinessLogic
{
    public class ClassBL
    {
        private ClassVM classVM;
        private ClassTypeVM typeVM;

        public ClassBL(IConfiguration config)
        {
            classVM = new ClassVM(config);
            typeVM = new ClassTypeVM(config);
        }

        // ----- שיעורים -----

        // הלקוח רואה רק שיעורים עתידיים שלא בוטלו
        public async Task<List<GymClass>> GetScheduleForClientAsync()
        {
            List<GymClass> all = await classVM.GetScheduleAsync(DateTime.Today);
            List<GymClass> result = new List<GymClass>();

            foreach (GymClass gc in all)
            {
                if (!gc.IsCancelled)
                {
                    result.Add(gc);
                }
            }
            return result;
        }

        public async Task<List<GymClass>> GetScheduleForManagerAsync(DateTime fromDate)
        {
            return await classVM.GetScheduleAsync(fromDate);
        }

        public async Task<ActionResultMsg> AddClassAsync(GymClass gc)
        {
            ActionResultMsg check = await ValidateClassAsync(gc, 0);
            if (!check.Success)
            {
                return check;
            }

            int newId = await classVM.AddAsync(gc);
            if (newId > 0)
            {
                return new ActionResultMsg(true, "השיעור נוסף ללוח הזמנים");
            }
            return new ActionResultMsg(false, "הוספת השיעור נכשלה");
        }

        public async Task<ActionResultMsg> UpdateClassAsync(GymClass gc)
        {
            ActionResultMsg check = await ValidateClassAsync(gc, gc.ClassID);
            if (!check.Success)
            {
                return check;
            }

            GymClass? current = await classVM.GetByIdAsync(gc.ClassID);
            if (current != null && gc.MaxParticipants < current.TakenPlaces)
            {
                return new ActionResultMsg(false,
                    "כבר נרשמו " + current.TakenPlaces + " מתאמנים, אי אפשר להקטין מתחת למספר הזה");
            }

            bool ok = await classVM.UpdateAsync(gc);
            return ok
                ? new ActionResultMsg(true, "פרטי השיעור עודכנו")
                : new ActionResultMsg(false, "השיעור לא נמצא");
        }

        public async Task<ActionResultMsg> CancelClassAsync(int classId)
        {
            GymClass? gc = await classVM.GetByIdAsync(classId);
            if (gc == null)
            {
                return new ActionResultMsg(false, "השיעור לא נמצא");
            }
            if (gc.IsCancelled)
            {
                return new ActionResultMsg(false, "השיעור כבר מבוטל");
            }

            bool ok = await classVM.CancelClassAsync(classId);
            return ok
                ? new ActionResultMsg(true, "השיעור בוטל וכל ההזמנות אליו בוטלו")
                : new ActionResultMsg(false, "ביטול השיעור נכשל");
        }

        private async Task<ActionResultMsg> ValidateClassAsync(GymClass gc, int excludeId)
        {
            if (gc.ClassDate.Date < DateTime.Today)
            {
                return new ActionResultMsg(false, "אי אפשר לפתוח שיעור בתאריך שעבר");
            }

            if (string.IsNullOrWhiteSpace(gc.TrainerName))
            {
                return new ActionResultMsg(false, "יש להזין שם מאמן");
            }

            if (gc.MaxParticipants < 1 || gc.MaxParticipants > 60)
            {
                return new ActionResultMsg(false, "מספר המשתתפים חייב להיות בין 1 ל-60");
            }

            // שעות הפעילות של המכון
            if (gc.StartTime < new TimeSpan(6, 0, 0) || gc.StartTime > new TimeSpan(22, 0, 0))
            {
                return new ActionResultMsg(false, "שעת השיעור חייבת להיות בין 06:00 ל-22:00");
            }

            if (await classVM.IsRoomBusyAsync(gc.ClassDate, gc.StartTime, gc.RoomName, excludeId))
            {
                return new ActionResultMsg(false, "האולם כבר תפוס בתאריך ובשעה האלה");
            }

            return new ActionResultMsg(true, "");
        }

        // ----- סוגי שיעורים -----

        public async Task<List<ClassType>> GetAllTypesAsync()
        {
            return await typeVM.GetAllAsync();
        }

        public async Task<ActionResultMsg> AddTypeAsync(ClassType t)
        {
            ActionResultMsg check = ValidateType(t);
            if (!check.Success)
            {
                return check;
            }

            // בודקים לבד כדי להחזיר הודעה ברורה ולא שגיאה של המסד
            List<ClassType> existing = await typeVM.GetAllAsync();
            foreach (ClassType ex in existing)
            {
                if (ex.TypeName == t.TypeName.Trim())
                {
                    return new ActionResultMsg(false, "כבר קיים סוג שיעור בשם הזה");
                }
            }

            t.TypeName = t.TypeName.Trim();
            int newId = await typeVM.AddAsync(t);

            return newId > 0
                ? new ActionResultMsg(true, "סוג השיעור נוסף")
                : new ActionResultMsg(false, "הוספת סוג השיעור נכשלה");
        }

        public async Task<ActionResultMsg> UpdateTypeAsync(ClassType t)
        {
            ActionResultMsg check = ValidateType(t);
            if (!check.Success)
            {
                return check;
            }

            bool ok = await typeVM.UpdateAsync(t);
            return ok
                ? new ActionResultMsg(true, "סוג השיעור עודכן")
                : new ActionResultMsg(false, "סוג השיעור לא נמצא");
        }

        public async Task<ActionResultMsg> DeleteTypeAsync(int typeId)
        {
            int howMany = await typeVM.CountClassesOfTypeAsync(typeId);
            if (howMany > 0)
            {
                return new ActionResultMsg(false,
                    "אי אפשר למחוק - קיימים " + howMany + " שיעורים מהסוג הזה");
            }

            bool ok = await typeVM.DeleteAsync(typeId);
            return ok
                ? new ActionResultMsg(true, "סוג השיעור נמחק")
                : new ActionResultMsg(false, "סוג השיעור לא נמצא");
        }

        private ActionResultMsg ValidateType(ClassType t)
        {
            if (string.IsNullOrWhiteSpace(t.TypeName))
            {
                return new ActionResultMsg(false, "יש להזין שם לסוג השיעור");
            }
            if (t.DurationMinutes < 15 || t.DurationMinutes > 120)
            {
                return new ActionResultMsg(false, "משך השיעור חייב להיות בין 15 ל-120 דקות");
            }
            return new ActionResultMsg(true, "");
        }
    }
}
