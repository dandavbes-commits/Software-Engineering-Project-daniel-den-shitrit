namespace GymTimeServer.Models
{
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
}
