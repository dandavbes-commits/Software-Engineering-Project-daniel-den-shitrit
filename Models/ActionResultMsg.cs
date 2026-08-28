namespace GymTimeServer.Models
{
    // תשובה אחידה שהשרת מחזיר על פעולות של הוספה/עדכון/מחיקה
    public class ActionResultMsg
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";

        public ActionResultMsg() { }

        public ActionResultMsg(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
