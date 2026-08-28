namespace GymTimeServer.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int ClientID { get; set; }
        public int ClassID { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; } = "";

        // מגיע מה-JOIN
        public string ClientName { get; set; } = "";
        public string ClientPhone { get; set; } = "";
        public string TypeName { get; set; } = "";
        public string TrainerName { get; set; } = "";
        public DateTime ClassDate { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}
