namespace GymTimeServer.Models
{
    // Class זו מילה שמורה אז קראתי לזה GymClass
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

        // מגיע מה-JOIN ומהספירה, לא מהטבלה עצמה
        public string TypeName { get; set; } = "";
        public int DurationMinutes { get; set; }
        public int TakenPlaces { get; set; }

        public int FreePlaces
        {
            get { return MaxParticipants - TakenPlaces; }
        }
    }
}
