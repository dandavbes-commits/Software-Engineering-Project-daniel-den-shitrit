namespace GymTimeClient.Models
{
    // אותן מחלקות כמו בשרת - השמות חייבים להיות זהים בשביל ה-JSON

    public class Client
    {
        public int ClientID { get; set; }
        public string FullName { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string UserPassword { get; set; } = "";
        public bool IsManager { get; set; }
        public DateTime JoinDate { get; set; }
    }

    public class ClassType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; } = "";
        public string TypeDescription { get; set; } = "";
        public int DurationMinutes { get; set; }

        // בשביל ה-ComboBox
        public override string ToString()
        {
            return TypeName;
        }
    }

    public class GymClass
    {
        public int ClassID { get; set; }
        public int TypeID { get; set; }
        public string TrainerName { get; set; } = "";
        public DateTime ClassDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int MaxParticipants { get; set; }
        public string RoomName { get; set; } = "";
        public bool IsCancelled { get; set; }
        public string TypeName { get; set; } = "";
        public int DurationMinutes { get; set; }
        public int TakenPlaces { get; set; }

        public int FreePlaces
        {
            get { return MaxParticipants - TakenPlaces; }
        }

        // עמודות מוכנות לתצוגה בטבלה
        public string DateText
        {
            get { return ClassDate.ToString("dd/MM/yyyy"); }
        }

        public string TimeText
        {
            get { return StartTime.ToString(@"hh\:mm"); }
        }

        public string PlacesText
        {
            get { return FreePlaces + " מתוך " + MaxParticipants; }
        }

        public string StatusText
        {
            get { return IsCancelled ? "מבוטל" : "פעיל"; }
        }
    }

    public class Booking
    {
        public int BookingID { get; set; }
        public int ClientID { get; set; }
        public int ClassID { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string ClientPhone { get; set; } = "";
        public string TypeName { get; set; } = "";
        public string TrainerName { get; set; } = "";
        public DateTime ClassDate { get; set; }
        public TimeSpan StartTime { get; set; }

        public string DateText
        {
            get { return ClassDate.ToString("dd/MM/yyyy"); }
        }

        public string TimeText
        {
            get { return StartTime.ToString(@"hh\:mm"); }
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class ActionResultMsg
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
    }
}
