namespace GymTimeServer.Models
{
    public class ClassType
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; } = "";
        public string TypeDescription { get; set; } = "";
        public int DurationMinutes { get; set; }
    }
}
