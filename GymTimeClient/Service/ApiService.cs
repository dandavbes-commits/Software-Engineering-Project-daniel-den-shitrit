using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using GymTimeClient.Models;

namespace GymTimeClient.Service
{
    // המחלקה היחידה שמדברת עם השרת
    public static class ApiService
    {
        private const string BASE_URL = "http://localhost:5215/";

        // HttpClient אחד לכל התוכנית, לא אחד לכל בקשה
        private static readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri(BASE_URL),
            Timeout = TimeSpan.FromSeconds(15)
        };

        private static readonly JsonSerializerOptions jsonOptions =
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static Client? CurrentUser { get; set; }

        // ----------------- משתמשים -----------------

        public static async Task<Client?> LoginAsync(string userName, string password)
        {
            LoginRequest request = new LoginRequest
            {
                UserName = userName,
                Password = password
            };

            HttpResponseMessage response =
                await http.PostAsJsonAsync("api/clients/login", request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return await response.Content.ReadFromJsonAsync<Client>(jsonOptions);
        }

        public static async Task<ActionResultMsg> RegisterAsync(Client c)
        {
            return await SendAsync(HttpMethod.Post, "api/clients/register", c);
        }

        // ----------------- סוגי שיעורים -----------------

        public static async Task<List<ClassType>> GetTypesAsync()
        {
            return await GetListAsync<ClassType>("api/classtypes");
        }

        public static async Task<ActionResultMsg> AddTypeAsync(ClassType t)
        {
            return await SendAsync(HttpMethod.Post, "api/classtypes", t);
        }

        public static async Task<ActionResultMsg> UpdateTypeAsync(ClassType t)
        {
            return await SendAsync(HttpMethod.Put, "api/classtypes/" + t.TypeID, t);
        }

        public static async Task<ActionResultMsg> DeleteTypeAsync(int typeId)
        {
            return await SendAsync(HttpMethod.Delete, "api/classtypes/" + typeId, null);
        }

        // ----------------- שיעורים -----------------

        public static async Task<List<GymClass>> GetScheduleAsync()
        {
            return await GetListAsync<GymClass>("api/classes/schedule");
        }

        public static async Task<List<GymClass>> GetManagerScheduleAsync(DateTime fromDate)
        {
            string url = "api/classes/manager?fromDate=" + fromDate.ToString("yyyy-MM-dd");
            return await GetListAsync<GymClass>(url);
        }

        public static async Task<ActionResultMsg> AddClassAsync(GymClass gc)
        {
            return await SendAsync(HttpMethod.Post, "api/classes", gc);
        }

        public static async Task<ActionResultMsg> UpdateClassAsync(GymClass gc)
        {
            return await SendAsync(HttpMethod.Put, "api/classes/" + gc.ClassID, gc);
        }

        public static async Task<ActionResultMsg> CancelClassAsync(int classId)
        {
            return await SendAsync(HttpMethod.Put, "api/classes/" + classId + "/cancel", null);
        }

        // ----------------- הזמנות -----------------

        public static async Task<List<Booking>> GetMyBookingsAsync(int clientId)
        {
            return await GetListAsync<Booking>("api/bookings/client/" + clientId);
        }

        public static async Task<List<Booking>> GetClassParticipantsAsync(int classId)
        {
            return await GetListAsync<Booking>("api/bookings/class/" + classId);
        }

        public static async Task<ActionResultMsg> BookClassAsync(int clientId, int classId)
        {
            Booking b = new Booking { ClientID = clientId, ClassID = classId };
            return await SendAsync(HttpMethod.Post, "api/bookings", b);
        }

        public static async Task<ActionResultMsg> CancelMyBookingAsync(int bookingId, int clientId)
        {
            string url = "api/bookings/" + bookingId + "/cancel?clientId=" + clientId;
            return await SendAsync(HttpMethod.Put, url, null);
        }

        public static async Task<ActionResultMsg> ChangeStatusAsync(int bookingId, string status)
        {
            string url = "api/bookings/" + bookingId + "/status";
            return await SendAsync(HttpMethod.Put, url, status);
        }

        // ----------------- עזר -----------------

        // גנרית כדי לא לכתוב את אותו קוד לכל טבלה
        private static async Task<List<T>> GetListAsync<T>(string url)
        {
            HttpResponseMessage response = await http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<T>();
            }

            List<T>? list = await response.Content.ReadFromJsonAsync<List<T>>(jsonOptions);
            return list ?? new List<T>();
        }

        // עובד גם על הצלחה וגם על שגיאה, בשניהם הגוף הוא ActionResultMsg
        private static async Task<ActionResultMsg> SendAsync(
            HttpMethod method, string url, object? body)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (body != null)
            {
                request.Content = JsonContent.Create(body, body.GetType());
            }

            HttpResponseMessage response = await http.SendAsync(request);

            ActionResultMsg? result =
                await response.Content.ReadFromJsonAsync<ActionResultMsg>(jsonOptions);

            if (result == null)
            {
                return new ActionResultMsg
                {
                    Success = false,
                    Message = "לא התקבלה תשובה מהשרת"
                };
            }
            return result;
        }
    }
}
